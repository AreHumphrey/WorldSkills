using Backend.Domain.Entities.Common;
using Backend.Domain.Entities.WorkEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace Backend.Persistence.Context
{
	public class ApplicaitonDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
		public DbSet<Users> Users { get; set; }
		public DbSet<Results> Results { get; set; }
		public DbSet<Roles> Roles { get; set; }
		public DbSet<Regions> Regions { get; set; }
		public DbSet<Volunteers> Volunteers { get; set; }
		public DbSet<Events> Events { get; set; }
		public DbSet<Skills> Skills { get; set; }
		public DbSet<Championships> Championships { get; set; }
		public DbSet<Competence> Competences { get; set; }
		public DbSet<ExpertCompetence> ExpertCompetences { get; set; }
		public DbSet<UsersChampionshipsCompetences> UsersChampionshipsCompetences { get; set; }
		public DbSet<CompetencesChampionships> CompetencesChampionships { get; set; }
		public DbSet<VolunteersChampionshipsCompetences> VolunteersChampionshipsCompetences { get; set; }
		public ApplicaitonDbContext(DbContextOptions<ApplicaitonDbContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {
			base.OnModelCreating(builder);
			builder.Ignore<IdentityRole>();
			builder.Ignore<IdentityRoleClaim<string>>();
			builder.Ignore<IdentityUserRole<string>>();
        }
    }
}
