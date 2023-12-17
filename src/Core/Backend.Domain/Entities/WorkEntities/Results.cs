using Backend.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Results : BaseEntity
	{
		public int Competition_number { get; set; }

		public string? Competition_name { get; set; }

        [ForeignKey("Competitionship_code")]
        public Championships Championships { get; set; }

		public float Mark {  get; set; }

		public string? Modules { get; set; }

		[ForeignKey("User_id")]
		public Users Users { get; set; }
	}
}
