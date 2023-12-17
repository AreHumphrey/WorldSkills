using Backend.Domain.Entities.Common;

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
