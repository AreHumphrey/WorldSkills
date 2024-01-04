using Backend.Persistence.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.WebApi.Controllers.WatchController
{
    [Route("api/[controller]")]
    [ApiController]
    public class WatchController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;

        public WatchController(ApplicaitonDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetTime() 
        {
            var champ = await _db.Championships.Where(ch => ch.is_over == false)
                                               .OrderBy(ch => ch.Dates)
                                               .FirstOrDefaultAsync();

            if (champ == null) 
            {
                return BadRequest();
            }

            DateTime dateTime = DateTime.Now;

            var untill = champ.Dates - dateTime;
            if (untill < TimeSpan.Zero)
                untill = TimeSpan.Zero;

            return Ok(untill);
        }
    }
}
