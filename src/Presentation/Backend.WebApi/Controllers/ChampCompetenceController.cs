using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampCompetenceController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public ChampCompetenceController(ApplicaitonDbContext db)
        {
            _db = db;
        }


        [Authorize]
        [HttpGet("users/{champId}&{compId}")]
        public async Task<IActionResult> GetUsersOfCompetenceOfChamp
            (int champId, string compId)
        {
            List<Users>? users = await _db.UsersChampionshipsCompetences
                                            .Where(a => a.ChampionshipsId == champId
                                            && a.CompetenceId == compId)
                                            .Include(a => a.Users)
                                            .Include(a => a.Users.Regions)
                                            .Select(a => a.Users)
                                            .Where(a => a.Roles.Role == "U")
                                            .ToListAsync();

            if (users == null)
            {
                return NotFound("Не найдено ни одного участника");
            }

            JArray jArray = new JArray();
            foreach (var user in users)
            {
                UserViewModel expertModel = new UserViewModel
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Gender = user.Gender,
                    Regionname = user.Regions.Name,
                };
                JObject json = JObject.FromObject(expertModel);
                jArray.Add(json);
            }

            return Ok(jArray.ToString());
        }

        [Authorize]
        [HttpGet("experts/{champId}&{compId}")]
        public async Task<IActionResult> GetExpertsOfCompetenceOfChamp
            (int champId, string compId)
        {
            List<Users>? experts = await _db.UsersChampionshipsCompetences
                                            .Where(a => a.ChampionshipsId == champId
                                            && a.CompetenceId == compId)
                                            .Include(a => a.Users)
                                            .Include(a => a.Users.Regions)
                                            .Select(a => a.Users)
                                            .Where(a => a.Roles.Role == "E")
                                            .ToListAsync();

            if (experts == null)
            {
                return NotFound("Не найдено ни одного эксперта");
            }

            JArray jArray = new JArray();
            foreach (var expert in experts)
            {
                UserViewModel expertModel = new UserViewModel
                {
                    FirstName = expert.FirstName,
                    LastName = expert.LastName,
                    Gender = expert.Gender,
                    Regionname = expert.Regions.Name,
                };
                JObject json = JObject.FromObject(expertModel);
                jArray.Add(json);
            }

            return Ok(jArray.ToString());
        }
    }
}
