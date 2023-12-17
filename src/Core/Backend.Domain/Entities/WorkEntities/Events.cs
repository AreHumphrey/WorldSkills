using Backend.Domain.Entities.Common;

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
