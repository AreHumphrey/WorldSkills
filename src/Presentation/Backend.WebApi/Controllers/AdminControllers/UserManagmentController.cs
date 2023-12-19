using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System.Security.Claims;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserManagmentController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;

        public UserManagmentController(ApplicaitonDbContext db, UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public async Task<IActionResult> RegistrateToChampionship()
        {
            List<Users>? users = await _db.Users.Include(a => a.Regions).Include(a => a.Roles).ToListAsync();
            if (users.IsNullOrEmpty()) 
            {
                return NotFound("Ни одного пользователя не найдено в системе");
            }

            JArray jArray = new JArray();
            foreach (var user in users) 
            {
                AdminUserToJSON userJSON = new AdminUserToJSON
                {
                    IdNumber = user.Id,
                    Email = user.UserName,
                    Name = user.FirstName + " " + user.LastName,
                    Gender = user.Gender,
                    Area = user.Regions.Area,
                    Region = user.Regions.Name,
                    RoleName = user.Roles.Role
                };

                JObject userJOBJ = JObject.FromObject(userJSON);
                jArray.Add(userJOBJ);
            }

            return Ok(jArray.ToString());
        }

        [Authorize(Roles = "A")]
        [HttpPut]
        public async Task<IActionResult> RegistrateToChampionship([FromBody] AddUserToChampionateModel UserCompChamp)
        {
            Users? user = await _userManager.FindByNameAsync(UserCompChamp.email);
            if (user == null)
            {
                return NotFound("Пользователь не найден в базе");
            }

            if (await _db.Championships.AnyAsync(a => a.Id == UserCompChamp.champId && a.is_over)) 
            {
                return BadRequest("Чемпионат уже окончен");
            }

            if (!await _db.CompetencesChampionships.AnyAsync(a => a.CompetenceId == UserCompChamp.compCode 
            && a.ChampionshipsId == UserCompChamp.champId))
            {
                return BadRequest("Чемпионат не содержит компетенции с таким кодом");
            }

            if (!await _db.UsersChampionshipsCompetences.AnyAsync(a => a.UsersId == user.Id))
            {
                return BadRequest("Пользователь уже зарегестрирован на данном чемпионате");
            }

            UsersChampionshipsCompetences ucc = new UsersChampionshipsCompetences
            {
                UsersId = user.Id,
                CompetenceId = UserCompChamp.compCode,
                ChampionshipsId = UserCompChamp.champId
            };

            await _db.UsersChampionshipsCompetences.AddAsync( ucc );
            Championships champ = await _db.Championships.FindAsync(UserCompChamp.champId);
            champ.Members_count = champ.Members_count + 1;

            int rows = await _db.SaveChangesAsync();

            if (rows == 0) 
            {
                return StatusCode(500, "Internal Server Error");
            }

            return Ok();
        }
    }
}
