using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;


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

		public List<Results>? UserResults { get; set; }
	}
}
