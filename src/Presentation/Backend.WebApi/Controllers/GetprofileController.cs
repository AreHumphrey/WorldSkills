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

            Regions? region = user.Regions;

            if (user == null) 
            {
                return NotFound();
            }

            UserToJSON userToJSON = new UserToJSON
            {
                Name = user.FirstName + " " + user.LastName,
                Gender = user.Gender,
                IdNumber = user.Id,
                Region = region.Name,
                Area = region.Area
            };

            JObject json = JObject.FromObject(userToJSON);

            return Ok(json.ToString());
        }

        [Authorize]
        [HttpGet("getrole")]
        public IActionResult GetUserRole() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? role = "";
            if (identity != null)
            {
                role = identity.FindFirst(ClaimTypes.Role)?.Value;
            }
            else
            {
                return NotFound("У пользователя нет claims");
            }

            return Ok(role);
        }
    }
}
