using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Roles : BaseEntity
	{
		[Column(TypeName = "VARCHAR(1)")]
		public required string Role {  get; set; }

		public string? Description { get; set; }
	}
}
