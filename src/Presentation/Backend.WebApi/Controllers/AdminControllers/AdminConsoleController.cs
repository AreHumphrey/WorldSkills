using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System.Security.Claims;

namespace Backend.WebApi.Controllers.AdminControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminConsoleController : ControllerBase
    {
        private readonly ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;

        public AdminConsoleController(ApplicaitonDbContext db, UserManager<Users> userManager) 
        {
            _db = db;
            _userManager = userManager;
        }

        [HttpGet("getapi")]
        public ActionResult<List<string>> Get()
        {
            var assembly = Assembly.GetEntryAssembly();
            var controllers = assembly.GetTypes()
                .Where(type => typeof(ControllerBase).IsAssignableFrom(type))
                .Select(type => type.Name)
                .ToList();
            return controllers;
        }
    }
}
