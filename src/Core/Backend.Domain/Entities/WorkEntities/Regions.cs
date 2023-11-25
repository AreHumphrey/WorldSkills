using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Regions : BaseEntity
	{
		public required string Name {  get; set; }

		public string? Capital {  get; set; }

		public string? Area { get; set; }
	}
}
