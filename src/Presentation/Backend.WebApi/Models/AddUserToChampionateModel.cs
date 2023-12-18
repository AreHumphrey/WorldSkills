namespace Backend.WebApi.Models
{
    public class AddUserToChampionateModel
    {
        public required string email { get; set; }
        public required int champId { get; set; }
        public required string compCode { get; set; }
    }
}
