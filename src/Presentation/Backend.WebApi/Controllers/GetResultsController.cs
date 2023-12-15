using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetResultsController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;
        public GetResultsController(ApplicaitonDbContext db, UserManager<Users> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]

        public async Task<IActionResult> Getresults() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? email = "";
            if (identity != null)
            {
                email = identity.FindFirst(ClaimTypes.Email)?.Value;

                if (email == null) 
                {
                    return NotFound("Для пользователя не найден email");
                }
            }
            else 
            {
                return NotFound("Для пользовтеля не найдены claims");
            }

            Users? user = await _db.Users.Where(a => a.UserName == email)
                                         .FirstOrDefaultAsync();

            if (user == null) 
            {
                return NotFound("Пользователь не найден");
            }

            user.UserResults = await _db.Results.Where(a => a.Users.Id == user.Id)
                                                .Include(b => b.Championships)
                                                .ToListAsync();

            if (user.UserResults.IsNullOrEmpty()) 
            {
                return NotFound("У пользователя нет результатов");
            }

            JObject json = new JObject();
            int i = 1;
            foreach (Backend.Domain.Entities.WorkEntities.Results a in user.UserResults)
            {
                ResultsToJSON res = new ResultsToJSON
                {
                    ChampName = a.Competition_name,
                    Competence = a.Competition_number,
                    ParticipantID = a.Users.Id,
                    Module = a.Modules,
                    Grade = a.Mark
                };

                JProperty property = new JProperty("Result " + i);
                property.Value = JObject.FromObject(res);
                json.Add(property);
                i++;
            }

            return Ok(json.ToString());            
        }
    }
}
