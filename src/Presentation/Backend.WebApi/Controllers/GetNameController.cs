using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetNameController : ControllerBase
    {
        [Authorize]
        [HttpGet]
        public IActionResult Getname()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string? name = "";
            string? surname = "";
            if (identity != null)
            {
                name = identity.FindFirst("FirstName")?.Value;
                surname = identity.FindFirst("LastName")?.Value;
            }
            else
            {
                return NotFound("У пользователя нет claims");
            }

            return Ok(name + " " + surname);
        }
    }
}
