using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
    public class ExpertCompetence : BaseEntity
    {
        public required string UsersId { get; set; }
        [ForeignKey("UsersId")]
        public Users Users { get; set; }

        public required string CompetenceId { get; set; }
        [ForeignKey("CompetenceId")]
        public Competence Competence { get; set; }
    }
}
