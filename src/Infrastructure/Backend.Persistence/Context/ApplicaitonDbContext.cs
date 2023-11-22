using Backend.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace Backend.Persistence.Context
{
	public class ApplicaitonDbContext : DbContext
	{
		public ApplicaitonDbContext(DbContextOptions options) : base(options)
		{
		}

		// Entityleri db ye kaydederken i�erdi�i dateTime propertylerini otomatik olarak ekleyen bir metod
		// Not : E�er PostgreSql kullanacaksan�z DateTime yerine DateTime.Utc.Now Kullanman�z gerekiyor

		// A method that automatically adds dateTime properties contained in entities while saving to the database
		// Note: If you're using PostgreSql, you need to use DateTime.Utc.Now instead of DateTime
		public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			var datas = ChangeTracker.Entries<IEntity>();
			foreach (var data in datas)
			{
				_ = data.State switch
				{
					EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
					EntityState.Modified => data.Entity.ModifiedDate = DateTime.Now,
					_ => DateTime.Now
				};
			}
			return await base.SaveChangesAsync(cancellationToken);
		}
	}
}
