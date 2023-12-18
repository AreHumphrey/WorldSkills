using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangeemailController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private readonly UserManager<Users> _userManager;

        public ChangeemailController(ApplicaitonDbContext db, UserManager<Users> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        [Authorize]
        [HttpPatch]
        public async Task<IActionResult> Changeemail([FromBody] string newEmail) 
        {
            string? currEmail = "";
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            currEmail = identity.FindFirst(ClaimTypes.Email)?.Value;

            Users? user = await _userManager.FindByNameAsync(currEmail);
            if (user == null) 
            {
                return NotFound("Пользователь не найден в системе");
            }

            user.UserName = newEmail;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) 
            {
                return StatusCode(500, "Internal Server Error");
            }

            return Ok();
        }
    }
}
