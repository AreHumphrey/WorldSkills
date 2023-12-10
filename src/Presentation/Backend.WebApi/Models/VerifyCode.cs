using Microsoft.AspNetCore.Mvc;

namespace Backend.WebApi.Models
{
    public class VerifyCode
    {
        public required string Email { get; set; }

        public required string Code { get; set; }
    }
}
