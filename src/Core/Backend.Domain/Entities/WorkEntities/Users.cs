using Backend.Domain.Entities.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Entities.WorkEntities
{
	public class Users : IdentityUser
	{
		public required string Email { get; set; }

		public required string Password { get; set; }

		public string? FirstName { get; set; }

		public string? LastName { get; set; }

		[ForeignKey("Role_id")]
		public Roles Roles { get; set; }

		public string? Gender { get; set; }

		public DateTime DateOfBirth { get; set; }

		[ForeignKey("RegionCode")]
		public Regions Regions { get; set; }
	}
}
