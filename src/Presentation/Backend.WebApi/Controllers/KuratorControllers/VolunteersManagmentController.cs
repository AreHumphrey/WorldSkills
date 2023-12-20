using Backend.Domain.Entities.WorkEntities;
using Backend.Infrastructure.VolunteersCSVEngine;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers.KuratorControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteersManagmentController : ControllerBase
    {
        private ApplicaitonDbContext _db;
        private IVolunteersCSV _volunteersCSV;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public VolunteersManagmentController(ApplicaitonDbContext db,
            IVolunteersCSV volunteersCSV, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _volunteersCSV = volunteersCSV;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "K")]
        [HttpPost("uploadvolunteers")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadVolunteers(IFormFile file) 
        {
            if (file == null || file.Length == 0 || file.ContentType != "text/csv") 
            {
                return BadRequest("Передан неверный файл");
            }

            string date = DateOnly.FromDateTime(DateTime.Now).ToString();
            string fileName = Path.GetFileNameWithoutExtension(file.Name);
            string fileExtantion = ".csv";
            string root = _webHostEnvironment.ContentRootPath;
            string filePath = Path.Combine(root, "Volunteers", date, fileName + fileExtantion);
            string dirPath = Path.Combine(root, "Volunteers", date);

            if (!System.IO.Directory.Exists(dirPath)) 
            {
                Directory.CreateDirectory(dirPath);
            }

            int counter = 1;
            while (System.IO.File.Exists(filePath)) 
            {
                filePath = Path.Combine(root, "Volunteers", date, fileName + $"({counter})" + fileExtantion);
                counter++;
            }

            using (var stream = new FileStream(filePath, FileMode.Create)) 
            {
                await file.CopyToAsync(stream);
            }

            List<Volunteers> volunteers = await _volunteersCSV.ReadCSVAsync(filePath);
            if (volunteers.IsNullOrEmpty()) 
            {
                return BadRequest($"Не удалось загрузить волонтёров из {file.FileName}");
            }

            await _db.Volunteers.AddRangeAsync(volunteers);

            int rows = await _db.SaveChangesAsync();
            if (rows == 0)
            {
                return StatusCode(500, "Internal Server Error");
            }
            else if (rows != volunteers.Count) 
            {
                return StatusCode(500, "Internal Server Error, Only part of volunteers was uploaded");
            }

            return Ok();
        }

        [Authorize(Roles = "K")]
        [HttpPut("addtochampcomp/{champId}&{compCode}")]
        public async Task<IActionResult> AddVolunteersToCompetence([FromBody] List<int> ids, 
            int champId, string compCode )  
        {
            List<int> existingIds = await _db.Volunteers.Select(v => v.Id).ToListAsync();

            if (!ids.All(id => existingIds.Contains(id))) 
            {
                return BadRequest("Один или несколько идентификаторов указывают на несуществующих волонтёров");
            }

            if (!await _db.CompetencesChampionships
                .AnyAsync(a => a.ChampionshipsId == champId && a.CompetenceId == compCode)) 
            {
                return BadRequest("В системе нет чемпионата с такой компетенцией");
            }

            List<VolunteersChampionshipsCompetences> volunteers = new List<VolunteersChampionshipsCompetences>();

            if (await _db.VolunteersChampionshipsCompetences.AnyAsync(a => a.VolunteerId == ids[0]))
            {
                volunteers = await _db.VolunteersChampionshipsCompetences
                    .Where(a => ids.Contains(a.VolunteerId))
                    .ToListAsync();

                foreach (var volunteer in volunteers) 
                {
                    volunteer.ChampionshipsId = champId;
                    volunteer.CompetenceId = compCode;
                }
            }
            else 
            {
                volunteers = ids.Select(id => new VolunteersChampionshipsCompetences
                {
                    VolunteerId = id,
                    ChampionshipsId = champId,
                    CompetenceId = compCode,
                    Championships = null,
                    Competence = null,
                    Volunteers = null
                }).ToList();
                await _db.VolunteersChampionshipsCompetences.AddRangeAsync(volunteers);
            }


            int rows = await _db.SaveChangesAsync();
            if (rows == 0)
            {
                return StatusCode(500, "Internal Server Error");
            }
            else if (rows != volunteers.Count) 
            {
                return StatusCode(500, "Internal Server Error Not All Volunteers was added");
            }

            return Ok();
        }

        [Authorize(Roles = "K")]
        [HttpGet("getvolunteers")]
        public async Task<IActionResult> GetVolunteers() 
        {
            var allVolunteers = await _db.Volunteers.ToListAsync();
            if (allVolunteers.IsNullOrEmpty()) 
            {
                return NotFound("В системе не зарегестрировано ни одного волонтёра");
            }

            var groupedVoluntears = await _db.VolunteersChampionshipsCompetences
                                   .Include(a => a.Volunteers)
                                   .GroupBy(a => a.CompetenceId)
                                   .Select(k => new
                                   {
                                       CompetenceId = k.Key,
                                       Entries = k.ToList()
                                   }).ToListAsync();

            JObject json = new JObject();
            foreach (var item in groupedVoluntears) 
            {
                JProperty jProperty = new JProperty(item.CompetenceId);
                JArray jArray = new JArray();
                foreach (var volunteer in item.Entries) 
                {
                    JObject jObject = JObject.FromObject(volunteer.Volunteers!);
                    jArray.Add(jObject);
                }
                jProperty.Value = jArray;
                json.Add(jProperty);
            }

            var volunteersFree = allVolunteers.Except(
                groupedVoluntears.SelectMany(a => a.Entries)
                .Select(a => a.Volunteers)).ToList();

            if (!volunteersFree.IsNullOrEmpty()) 
            {
                JProperty jProperty2 = new JProperty("default");
                JArray jArray2 = new JArray();
                foreach (var volunteer in volunteersFree) 
                {
                    JObject jObject2 = JObject.FromObject(volunteer!);
                    jArray2.Add(jObject2);
                }
                jProperty2.Value = jArray2;
                json.Add(jProperty2);
            }

            return Ok(json.ToString());
        }
    }
}
