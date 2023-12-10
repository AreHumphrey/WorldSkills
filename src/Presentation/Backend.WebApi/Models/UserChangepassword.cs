namespace Backend.WebApi.Models
{
    public class UserChangepassword
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
