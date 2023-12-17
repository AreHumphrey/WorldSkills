using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserChampionshipController : ControllerBase
    {
        private ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;

        public UserChampionshipController(ApplicaitonDbContext db, UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetCompetenceOfUserChampionship() 
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? email = "";
            string? role = "";

            if (identity != null)
            {
                email = identity.FindFirst(ClaimTypes.Email)?.Value;
                role = identity.FindFirst(ClaimTypes.Role)?.Value;

                if (role != "U") 
                {
                    return BadRequest("Данное api рассчитано на обычных пользователей");
                }
            }
            else 
            {
                return BadRequest("Токен повреждён пожалуйста войдите в систему повторно");
            }

            Users? user = await _userManager.FindByNameAsync(email);
            if (user == null) 
            {
                return NotFound("Пользователь с такой почтой не найден в системе");
            }

            UsersChampionshipsCompetences? userchamp = await _db.UsersChampionshipsCompetences
                                                           .Where(a => a.UsersId == user.Id)
                                                           .Include(a => a.Championships)
                                                           .Where(a => a.Championships.is_over == false)
                                                           .OrderBy(a => a.Championships.Dates)
                                                           .FirstOrDefaultAsync();

            if (userchamp == null) 
            {
                return BadRequest("Пользователь не участвует не в одном чемпионате");
            }

            CompetenceChampionshipModel initmodel = new CompetenceChampionshipModel
            {
                ChampionshipId = userchamp.ChampionshipsId,
                CompetenceId = userchamp.CompetenceId
            };

            JObject json = JObject.FromObject(initmodel);

            return Ok(json.ToString());
        }
    }
}
