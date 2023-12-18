namespace Backend.WebApi.Models
{
    public class BaseChampionshipModel
    {
        public required string Title { get; set; }

        public DateTime Dates { get; set; }

        public required string Place { get; set; }

        public string? Link { get; set; }

        public string? Adress { get; set; }
    }
}
