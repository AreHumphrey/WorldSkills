using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampCompetenceExpertsController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public ChampCompetenceExpertsController(ApplicaitonDbContext db)
        {
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetExpertsOfCompetenceOfChamp
            ([FromBody] CompetenceChampionshipModel ChampComp) 
        {
            List<Users>? experts = await _db.UsersChampionshipsCompetences
                                            .Where(a => a.ChampionshipsId == ChampComp.ChampionshipId
                                            && a.CompetenceId == ChampComp.CompetenceId)
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
