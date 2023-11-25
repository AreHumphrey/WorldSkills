using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Volunteers : BaseEntity
	{
		public required string FirstName { get; set; }
		public required string LastName { get; set;}

		[ForeignKey("RegionCode")]
		public Regions Regions { get; set; }

		public string? Gender { get; set; }

	}
}
