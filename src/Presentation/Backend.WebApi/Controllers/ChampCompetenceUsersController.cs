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
    public class ChampCompetenceUsersController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public ChampCompetenceUsersController(ApplicaitonDbContext db)
        {
            _db = db;
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUsersOfCompetenceOfChamp
            ([FromBody] CompetenceChampionshipModel ChampComp)
        {
            List<Users>? users = await _db.UsersChampionshipsCompetences
                                            .Where(a => a.ChampionshipsId == ChampComp.ChampionshipId
                                            && a.CompetenceId == ChampComp.CompetenceId)
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
    }
}
