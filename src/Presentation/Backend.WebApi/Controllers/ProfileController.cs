using Backend.Domain.Entities.WorkEntities;
using Backend.Persistence.Context;
using Backend.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

#pragma warning disable CS8601 // Возможно, назначение-ссылка, допускающее значение NULL.
#pragma warning disable CS8600 // Преобразование литерала, допускающего значение NULL или возможного значения NULL в тип, не допускающий значение NULL.
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
#pragma warning disable CS8603 // Возможно, возврат ссылки, допускающей значение NULL.

namespace Backend.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private ApplicaitonDbContext _db;
		private IConfiguration _config;
        SHA256 sha256 = SHA256.Create();
		private UserManager<Users> _userManager;

        public LoginController(ApplicaitonDbContext db, IConfiguration config, UserManager<Users> userManager) 
		{
			_db = db;
			_config = config;
			_userManager = userManager;
		}

		[AllowAnonymous]
		[HttpPost]
		public IActionResult Login([FromBody] UserLogin userLogin) 
		{
			var user = Authenticate(userLogin);

			if (user != null) 
			{
				var token = Generate(user);

				return Ok(token);
			}

			return NotFound("Неправильный логин или пароль");
		}

        private string Generate(Users user)
        {
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
			{
				new Claim(ClaimTypes.Email, user.UserName),
				new Claim("FirstName", user.FirstName),
				new Claim("LastName", user.LastName),
				new Claim(ClaimTypes.Role, user.Roles.Id.ToString())
			};

            var token = new JwtSecurityToken(
				_config["Jwt:Issuer"],
				_config["Jwt:Audience"],
				claims,
				expires: DateTime.Now.AddDays(1),
				signingCredentials: credentials);

			return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private Users Authenticate(UserLogin userLogin)
        {
			string username = userLogin.Username;
			string password = Convert.ToHexString(
				sha256.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password)));

			var currUser = _db.Users
				.Where(a => a.UserName == username && a.Password == password)
				.FirstOrDefault();

			if (currUser != null) 
			{
				return currUser;
			}

            return null;
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
	{
        private ApplicaitonDbContext _db;
        private IConfiguration _config;
        SHA256 sha256 = SHA256.Create();
        private UserManager<Users> _userManager;

        public RegistrationController(ApplicaitonDbContext db, IConfiguration config, UserManager<Users> userManager)
        {
            _db = db;
            _config = config;
			_userManager = userManager;
        }

		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> Registration([FromBody] UserRegistration userRegistration) 
		{

            var user = _db.Users
				.Where(a => a.Email == userRegistration.Username)
				.FirstOrDefault();

			if (user == null) 
			{
				string password = Convert.ToHexString(
					sha256.ComputeHash(Encoding.UTF8.GetBytes(userRegistration.Password)));
				Roles role = _db.Roles.Find(1);
				Regions region = _db.Regions.Where(a => a.Name == userRegistration.Region).FirstOrDefault();
				if (region == null) 
				{
					Regions tmpR = new Regions
					{
						Name = userRegistration.Region,
						Area = "RF",
						Capital = "Non"
					};
					_db.Regions.Add(tmpR);
					_db.SaveChanges();
					region = tmpR;
				}
				Users newUser = new Users
				{
					UserName = userRegistration.Username,
					Email = userRegistration.Username,
					Password = password,
					FirstName = userRegistration.FirstName,
					LastName = userRegistration.LastName,
					Roles = role,
					Gender = userRegistration.Gender,
					DateOfBirth = System.DateTime.Parse(userRegistration.Birthday),
					Regions = region,
                };

				newUser.Email = userRegistration.Username;

				var result = await _userManager.CreateAsync(newUser);
				if (result.Succeeded)
				{
					return Ok("Зарегистрирован");
				}
				else 
				{
                    foreach (var error in result.Errors)
                    {
						System.Console.WriteLine(error.Description);
                    }
                }

			}

			return BadRequest("Такой пользователь уже существует");
		}
    }
}
