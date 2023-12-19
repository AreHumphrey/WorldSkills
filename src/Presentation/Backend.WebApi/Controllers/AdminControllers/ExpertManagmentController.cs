using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpertManagmentController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;

        public ExpertManagmentController(ApplicaitonDbContext db, UserManager<Users> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "A")]

        public async Task<IActionResult> GetAllExperts() 
        {
            List<Users> experts = await _db.Users.Include(a => a.Roles)
                                                 .Include(a => a.Regions)
                                                 .Where(a => a.Roles.Role == "E")
                                                 .ToListAsync();
            if (experts.IsNullOrEmpty()) 
            {
                return NotFound("Ни одного эксперта не найдено");
            }

            List<FullExpertModel> expertModels = new List<FullExpertModel>();
            foreach (var e in experts) 
            {
                FullExpertModel exp = new FullExpertModel
                {
                    Id = e.Id,
                    Username = e.UserName,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Gender = e.Gender,
                    Birthday = e.DateOfBirth.ToString(),
                    Regioncode = e.Regions.Area,
                    Regionname = e.Regions.Name
                };

                expertModels.Add(exp);
            }

            return Ok(expertModels);
        }

        [HttpDelete]
        [Authorize(Roles = "A")]

        public async Task<IActionResult> DeleteExpert([FromBody] List<string> ids)
        {
            foreach (var id in ids) 
            {
                Users? user = await _userManager.FindByIdAsync(id);

                if (user != null) 
                {
                    await _userManager.DeleteAsync(user);
                }
            }

            return Ok();
        }

        [HttpPatch("addtoexperts")]
        [Authorize(Roles = "A")]

        public async Task<IActionResult> AddExpert([FromBody] List<string> ids)
        {
            foreach (var id in ids)
            {
                Users? user = await _userManager.FindByIdAsync(id);
                if (user == null) 
                {
                    return BadRequest("Неправильный id: " + id);
                }

                user.Roles = await _db.Roles.Where(a => a.Role == "E").FirstOrDefaultAsync();

                if (user.Roles == null) 
                {
                    return StatusCode(500, "Internail server errror");
                }

                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded) 
                {
                    return StatusCode(500, "Internail server errror on user with id: " + id);
                }
            }

            return Ok();
        }

        [Authorize(Roles = "A")]
        [HttpPut("addtochampionatecompetence")]
        public async Task<IActionResult> AddExpertToCompetence([FromBody] AddUserToChampionateModel ExpertCompChamp) 
        {
            Users? user = await _db.Users.Where(a => a.UserName == ExpertCompChamp.email)
                                         .Include(a => a.Roles)
                                         .FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("Пользователь не найден в базе");
            }

            if (user.Roles.Role != "E") 
            {
                return BadRequest("Данный пользователь не является экспертом");
            }

            if (await _db.Championships.AnyAsync(a => a.Id == ExpertCompChamp.champId && a.is_over))
            {
                return BadRequest("Чемпионат уже окончен");
            }

            if (!await _db.CompetencesChampionships.AnyAsync(a => a.CompetenceId == ExpertCompChamp.compCode
            && a.ChampionshipsId == ExpertCompChamp.champId))
            {
                return BadRequest("Чемпионат не содержит компетенции с таким кодом");
            }

            UsersChampionshipsCompetences ucc = new UsersChampionshipsCompetences
            {
                UsersId = user.Id,
                CompetenceId = ExpertCompChamp.compCode,
                ChampionshipsId = ExpertCompChamp.champId
            };

            await _db.UsersChampionshipsCompetences.AddAsync(ucc);

            int rows = await _db.SaveChangesAsync();

            if (rows == 0)
            {
                return StatusCode(500, "Internal Server Error");
            }

            return Ok();
        }
    }
}
