using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Newtonsoft.Json;
using Backend.WebApi.Models;

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

            Users? user = await _db.Users.Where(a => a.UserName == email).Include(a => a.Regions).FirstOrDefaultAsync();
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

            string json = JsonConvert.SerializeObject(userToJSON);
            return Ok(json);
        }
    }
}
