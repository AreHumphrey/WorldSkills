using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
    public class Competence : BaseEntity
    {
        [Key]
        [Column("Competence_code")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public new required string  Id { get; set; }
        public required string Name { get; set; }

        public required string Description { get; set; }

        
    }
}
