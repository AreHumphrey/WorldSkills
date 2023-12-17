using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
    public class CompetencesChampionships : BaseEntity
    {
        public required int ChampionshipsId { get; set; }
        [ForeignKey("ChampionshipsId")]
        public Championships Championships { get; set; }

        public required string CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public Competence Competence { get; set; }
    }
}
