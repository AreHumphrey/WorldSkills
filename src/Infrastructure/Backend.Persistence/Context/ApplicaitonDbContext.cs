using Backend.Domain.Entities.Common;
using Backend.Domain.Entities.WorkEntities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Backend.Persistence.Context
{
	public class ApplicaitonDbContext : DbContext
	{
		public DbSet<Users> Users { get; set; }
		public DbSet<Results> Results { get; set; }
		public DbSet<Roles> Roles { get; set; }
		public DbSet<Regions> Regions { get; set; }
		public DbSet<Volunteers> Volunteers { get; set; }
		public DbSet<Events> Events { get; set; }
		public DbSet<Skills> Skills { get; set; }
		public DbSet<Championships> Championships { get; set; }
		public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}
	}
}
