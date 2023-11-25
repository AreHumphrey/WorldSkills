using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Championships : BaseEntity
	{
		public required string Title { get; set; }

		public DateTime Dates { get; set; }

		public required string Place {  get; set; }

		public string? Link { get; set; }

		public string? Adress { get; set; }

		public int? Members_count { get; set; }
	}
}
