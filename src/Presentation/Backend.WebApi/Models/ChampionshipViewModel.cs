namespace Backend.WebApi.Models
{
    public class ChampionshipViewModel
    {
        public required int Id { get; set; }
        public required string Title { get; set; }

        public DateTime Dates { get; set; }

        public required string Place { get; set; }

        public string? Link { get; set; }

        public string? Adress { get; set; }

        public int? Members_count { get; set; }

    }
}
