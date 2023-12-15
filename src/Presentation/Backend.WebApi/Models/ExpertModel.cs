namespace Backend.WebApi.Models
{
    public class ExpertModel
    {
        public required string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Birthday { get; set; }
        public string Regioncode { get; set; }
        public string Regionname { get; set; }
    }
}

