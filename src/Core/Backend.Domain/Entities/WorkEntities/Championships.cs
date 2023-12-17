using Backend.Domain.Entities.Common;

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

		public required bool is_over {  get; set; }
	}
}
