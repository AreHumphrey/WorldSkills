namespace Backend.WebApi.Models
{
    public class UserRegistration
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Region { get; set; }
    }
}
