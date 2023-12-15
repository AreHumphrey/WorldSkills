﻿using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

            List<ExpertModel> expertModels = new List<ExpertModel>();
            foreach (var e in experts) 
            {
                ExpertModel exp = new ExpertModel
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
    }
}