namespace Backend.WebApi.Models
{
    public class FullExpertModel : UserViewModel
    {
        public required string Id { get; set; }
        public string Username { get; set; }
        public string Birthday { get; set; }
        public string Regioncode { get; set; }

    }
}

