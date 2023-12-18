namespace Backend.WebApi.Models
{
    public class ChampionshipViewModel : BaseChampionshipModel
    {
        public required int Id { get; set; }
        public int? Members_count { get; set; }
    }
}
