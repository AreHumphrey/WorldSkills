using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public ChampionshipsController(ApplicaitonDbContext db) 
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("link/{champId}")]
        public async Task<IActionResult> GetChampionshipLink(int champId) 
        {
            Championships? champ = await _db.Championships.FindAsync(champId);

            if (champ == null) 
            {
                return NotFound("Неправильный id чемпионата");
            }

            string address = champ.Adress;
            if (address.IsNullOrEmpty()) 
            {
                return BadRequest("Адрес не найден");
            }

            string geoAddress = System.Web.HttpUtility.UrlEncode(address);
            string mapUrl = $"https://yandex.ru/maps/?text={geoAddress}";

            return Ok(mapUrl);
        }

        [Authorize]
        [HttpGet("championates/upcoming")]
        public async Task<IActionResult> GetUpcomingChampionates() 
        {
            DateTime currDate = DateTime.Now;

            List<Championships> champs = await _db.Championships
                                        .Where(a => !a.is_over && a.Dates > currDate)
                                        .ToListAsync();

            JArray jArray = new JArray();
            foreach (var champ in champs) 
            {
                ChampionshipViewModel viewChamp = new ChampionshipViewModel
                {
                    Id = champ.Id,
                    Title = champ.Title,
                    Place = champ.Place,
                    Adress = champ.Adress,
                    Dates = champ.Dates,
                    Link = champ.Link,
                    Members_count = champ.Members_count
                };

                JObject jObject = JObject.FromObject(viewChamp);
                jArray.Add(jObject);
            }

            return Ok(jArray.ToString());
        }

        [Authorize]
        [HttpGet("championates/current")]
        public async Task<IActionResult> GetCurrentChampionates()
        {
            DateTime currDate = DateTime.Now;

            List<Championships> champs = await _db.Championships
                                        .Where(a => !a.is_over && a.Dates <= currDate)
                                        .ToListAsync();

            JArray jArray = new JArray();
            foreach (var champ in champs)
            {
                ChampionshipViewModel viewChamp = new ChampionshipViewModel
                {
                    Id = champ.Id,
                    Title = champ.Title,
                    Place = champ.Place,
                    Adress = champ.Adress,
                    Dates = champ.Dates,
                    Link = champ.Link,
                    Members_count = champ.Members_count
                };

                JObject jObject = JObject.FromObject(viewChamp);
                jArray.Add(jObject);
            }

            return Ok(jArray.ToString());
        }

        [Authorize]
        [HttpGet("championates/passed")]
        public async Task<IActionResult> GetPassedChampionates()
        {
            DateTime currDate = DateTime.Now;

            List<Championships> champs = await _db.Championships
                                        .Where(a => a.is_over)
                                        .ToListAsync();

            JArray jArray = new JArray();
            foreach (var champ in champs)
            {
                ChampionshipViewModel viewChamp = new ChampionshipViewModel
                {
                    Id = champ.Id,
                    Title = champ.Title,
                    Place = champ.Place,
                    Adress = champ.Adress,
                    Dates = champ.Dates,
                    Link = champ.Link,
                    Members_count = champ.Members_count
                };

                JObject jObject = JObject.FromObject(viewChamp);
                jArray.Add(jObject);
            }

            return Ok(jArray.ToString());
        }

        [Authorize]
        [HttpGet("championates/getcompetences/{champId}")]
        public async Task<IActionResult> GetChampionshipCompetences(int champId) 
        {
            List<Competence> competences = await _db.CompetencesChampionships
                                                                       .Where(a => a.ChampionshipsId == champId)
                                                                       .Include(a => a.Competence)
                                                                       .Select(a => a.Competence)
                                                                       .ToListAsync();

            JArray jArray = new JArray();
            foreach (var competence in competences)
            {
                CompetenceViewModel viewComp = new CompetenceViewModel
                {
                    Code = competence.Id,
                    Name = competence.Name,
                    Description = competence.Description
                };

                JObject jObject = JObject.FromObject(viewComp);
                jArray.Add(jObject);
            }

            return Ok(jArray.ToString());
        }
    }
}
