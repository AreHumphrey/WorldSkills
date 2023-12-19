using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
