using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetencesController : ControllerBase
    {
        private ApplicaitonDbContext _db;

        public CompetencesController(ApplicaitonDbContext db)
        {
            _db = db;
        }

        [Authorize(Roles = "A")]
        [HttpGet]
        public async Task<IActionResult> GetListOfCompetences() 
        {
            List<Competence> competences = await _db.Competences.ToListAsync();

            if (competences.IsNullOrEmpty()) 
            {
                return NotFound("Не найдено ни одной компетенции");
            }

            JArray jArray = new JArray();
            foreach (var competence in competences) 
            {
                JObject jObject = JObject.FromObject(competence);
                jArray.Add(jObject);
            }

            return Ok(jArray.ToString());
        }
    }
}
