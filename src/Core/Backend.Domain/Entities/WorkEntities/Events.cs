using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Events : BaseEntity
	{
		public required string Title { get; set; }

		public string? Description { get; set;}

		public DateTime Dates { get; set; }

		public string? Website { get; set; }
	}
}
