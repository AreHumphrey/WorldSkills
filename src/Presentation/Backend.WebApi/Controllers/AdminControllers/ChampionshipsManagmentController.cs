using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionshipsManagmentController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;

        public ChampionshipsManagmentController(ApplicaitonDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "A")]
        [HttpPost("addchampionship")]
        public async Task<IActionResult> AddChampionship([FromBody] BaseChampionshipModel champ) 
        {
            if (await _db.Championships.AnyAsync(a => a.Title == champ.Title && a.Dates == champ.Dates))
            {
                return BadRequest("Такой чемпионат уже есть в базе");
            }

            Championships championship = new Championships
            {
                Title = champ.Title,
                Dates = champ.Dates,
                Adress = champ.Adress,
                Link = champ.Link,
                Members_count = 0,
                Place = champ.Place,
                is_over = false
            };

            await _db.Championships.AddAsync(championship);

            int rows = await _db.SaveChangesAsync();
            if (rows == 0) 
            {
                return StatusCode(500, "Internal Server Error");
            }

            return Ok();
        }
    }
}
