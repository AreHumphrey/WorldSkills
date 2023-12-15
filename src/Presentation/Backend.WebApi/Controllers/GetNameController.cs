using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Newtonsoft.Json.Linq;

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
            string? gender = "";
            if (identity != null)
            {
                name = identity.FindFirst("FirstName")?.Value;
                surname = identity.FindFirst("LastName")?.Value;
                gender = identity.FindFirst(ClaimTypes.Gender)?.Value;
            }
            else
            {
                return NotFound("У пользователя нет claims");
            }

            JObject json = new JObject();
            json["name"] = name;
            json["surname"] = surname;
            json["gender"] = gender;

            return Ok(json.ToString());
        }
    }
}
