using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public ChampionshipsController(ApplicaitonDbContext db) 
        {
            _db = db;
        }

        [Authorize]
        [HttpGet("link/{champId}")]
        public async Task<IActionResult> GetChampionshipLink(int champId) 
        {
            Championships? champ = await _db.Championships.FindAsync(champId);

            if (champ == null) 
            {
                return NotFound("Неправильный id чемпионата");
            }

            string address = champ.Adress;
            if (address.IsNullOrEmpty()) 
            {
                return BadRequest("Адрес не найден");
            }

            string geoAddress = System.Web.HttpUtility.UrlEncode(address);
            string mapUrl = $"https://yandex.ru/maps/?text={geoAddress}";

            return Ok(mapUrl);
        }
    }
}
