using Microsoft.AspNetCore.Mvc;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authorization;
using Backend.Infrastructure.Email;
using Backend.Domain.Entities.WorkEntities;
using Microsoft.AspNetCore.Identity;
using Backend.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Backend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChangepasswordController : ControllerBase
    {
        private ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;
        SHA256 sha256 = SHA256.Create();

        public ChangepasswordController(ApplicaitonDbContext db, UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Changepassword([FromBody] UserChangepassword userChangepassword) 
        {
            var user = await _db.Users.Where(a => a.UserName == userChangepassword.Email).FirstOrDefaultAsync();
            if (user != null) 
            {
                string password = Convert.ToHexString(
                sha256.ComputeHash(Encoding.UTF8.GetBytes(userChangepassword.Password))); ;
                user.Password = password;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded) 
                {
                    return Ok();
                }

                return BadRequest();
            }

            return NotFound();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class SendcodeController : ControllerBase
    {
        private ApplicaitonDbContext _db;
        private readonly IEmailSender _emailSender;
        private UserManager<Users> _userManager;

        public SendcodeController(ApplicaitonDbContext db, IEmailSender emailSender, UserManager<Users> userManager)
        {
            _db = db;
            _emailSender = emailSender;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Sendcode([FromBody] EmailModel email)
        {
            string code = "";
            EmailTokenProvider<Users> tokenProvider = new EmailTokenProvider<Users>();

            var user = _db.Users.Where(a => a.UserName == email.Email).FirstOrDefault();
            if (user != null)
            {
                code = await tokenProvider.GenerateAsync("Email", _userManager, user);
                await _emailSender.SendEmailAsync(email.Email, "Смена пароля", code);
                return Ok();
            }

            return NotFound();
        }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class VerificodeController : ControllerBase
    {
        private ApplicaitonDbContext _db;
        private UserManager<Users> _userManager;

        public VerificodeController(ApplicaitonDbContext db, UserManager<Users> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Verifycode([FromBody] VerifyCode verifiCode)
        {
            var user = await _db.Users.Where(a => a.UserName == verifiCode.Email).FirstOrDefaultAsync();
            System.Console.WriteLine("email: " + verifiCode.Email);
            System.Console.WriteLine("code: " + verifiCode.Code);
            if (user != null)
            {
                EmailTokenProvider<Users> tokenProvider = new EmailTokenProvider<Users>();
                bool result = await tokenProvider.ValidateAsync("Email", verifiCode.Code, _userManager, user);

                if (result)
                {
                    return Ok();
                }

                return BadRequest("Код не верефицирован");
            }

            return NotFound("Пользователь не найден");
        }
    }
}
