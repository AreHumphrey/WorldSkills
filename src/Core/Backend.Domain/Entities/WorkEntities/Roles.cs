using Backend.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Roles : BaseEntity
	{
		[Column(TypeName = "VARCHAR(1)")]
		public required string Role {  get; set; }

		public string? Description { get; set; }
	}
}
