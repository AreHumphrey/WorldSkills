namespace Backend.WebApi.Models
{
    public class AdminUserToJSON : UserToJSON
    {
        public string RoleName { get; set; }
        public string Email { get; set; }
    }
}
