using Backend.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Volunteers : BaseEntity
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set;}

        [ForeignKey("RegionsId")]
        public required int RegionsId { get; set; }
        public Regions? Regions { get; set; }

		public string? Gender { get; set; }

	}
}
