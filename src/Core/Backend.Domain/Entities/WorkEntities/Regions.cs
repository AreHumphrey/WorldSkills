using Backend.Domain.Entities.Common;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Regions : BaseEntity
	{
		public required string Name {  get; set; }

		public string? Capital {  get; set; }

		public string? Area { get; set; }
	}
}
