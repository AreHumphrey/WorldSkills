using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KuratorsManagmentController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private readonly UserManager<Users> _userManager;

        public KuratorsManagmentController(ApplicaitonDbContext db, UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize(Roles = "A")]
        [HttpPatch("addtokurators")]
        public async Task<IActionResult> AddKurator([FromBody] List<string> ids) 
        {
            foreach (var id in ids)
            {
                Users? user = await _userManager.FindByIdAsync(id);
                if (user == null)
                {
                    return BadRequest("Неправильный id: " + id);
                }

                user.Roles = await _db.Roles.Where(a => a.Role == "K").FirstOrDefaultAsync();

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
