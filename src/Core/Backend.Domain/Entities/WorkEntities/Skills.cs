using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Skills : BaseEntity
	{
		public required string Name { get; set; }

		public string? WSI {  get; set; }

		public string? Description_RUS { get; set; }

		public string? Description_EN { get;}
	}
}
