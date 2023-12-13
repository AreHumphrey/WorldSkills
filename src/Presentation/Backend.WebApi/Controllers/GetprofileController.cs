using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Backend.WebApi.Models;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetprofileController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;

        public GetprofileController(ApplicaitonDbContext db) 
        {
            _db = db;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetProfileInfo() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? email = "";
            if (identity != null)
            {
                email = identity.FindFirst(ClaimTypes.Email)?.Value;
            }
            else 
            {
                return NotFound("У пользователя нет claims");
            }

            Users? user = await _db.Users.Where(a => a.UserName == email)
                                         .Include(a => a.Regions)
                                         .FirstOrDefaultAsync();

            user.UserResults = await _db.Results.Where(a => a.Users.Id == user.Id)
                                                .Include(b => b.Championships)
                                                .ToListAsync();

            Regions? region = user.Regions;

            if (user == null) 
            {
                return NotFound();
            }

            UserToJSON userToJSON = new UserToJSON
            {
                Name = user.FirstName,
                Gender = user.Gender,
                IdNumber = user.Id,
                Region = region.Name,
                Area = region.Area
            };

            JObject json = JObject.FromObject(userToJSON);

            JObject jObject = new JObject();
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

                JProperty property = new JProperty("Result" + i);
                property.Value = JObject.FromObject(res);
                jObject.Add(property);
                i++;
            }
            json["Results"] = jObject;

            return Ok(json.ToString());
        }
    }
}
