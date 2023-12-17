using Backend.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;


namespace Backend.Domain.Entities.WorkEntities
{
    public class UsersChampionshipsCompetences : BaseEntity
    {
        public required string UsersId { get; set; }
        [ForeignKey("UsersId")]
        public Users Users {  get; set; }

        public required int ChampionshipsId { get; set; }
        [ForeignKey("ChampionshipsId")]
        public Championships Championships {  get; set; }

        public required string CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public Competence Competence { get; set; }
    }
}
