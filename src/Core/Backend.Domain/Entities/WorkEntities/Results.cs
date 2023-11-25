using Backend.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Results : BaseEntity
	{
		public int Competition_number { get; set; }

		public string? Competition_name { get; set; }

		public int Competitionship_code { get; set; }

		public float Mark {  get; set; }

		public string? Modules { get; set; }

		[ForeignKey("User_id")]
		public Users Users { get; set; }
	}
}
