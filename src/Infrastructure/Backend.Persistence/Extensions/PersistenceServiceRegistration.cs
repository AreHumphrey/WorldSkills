using Backend.Application.Abstractions.Repositories.Common;
using Backend.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Backend.Domain.Entities.WorkEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace Backend.Persistence.Extensions
{
	public static class PersistenceServiceRegistration
	{
		// Bu projede kullanacaðýnýz servisleri IoC mekanizmasýna ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDb(configuration);
            services.AddMyIdentity();

            return services;
		}

        // Repository lerin otomatik olarak IoC Container a eklenmesini saðlayan metod
        //Method that enables automatic addition of repositories to IoC Container
        private static IServiceCollection AddRepositoryToIoC(IServiceCollection services, Assembly assembly)
		{
			var reposiories = assembly.GetTypes().Where(x => x.IsAssignableToGenericType(typeof(IRepository<>)) && !x.IsGenericType);
			foreach (var item in reposiories)
			{
				var @interface = item.GetInterfaces().FirstOrDefault(x => !x.IsGenericType) ?? throw new ArgumentNullException();
				services.AddScoped(@interface, item);
			}
			return services;
		}


		//Type in verilen generic türden türeyip türemediðini kontrol eden fonksiyon
		//Function that checks whether a given type is implementing a generic interface
		private static bool IsAssignableToGenericType(this Type givenType, Type genericType)
		{
			return givenType.GetInterfaces().Any(t => t.IsGenericType && t.GetGenericTypeDefinition() == genericType) ||
				   givenType.BaseType != null && (givenType.BaseType.IsGenericType && givenType.BaseType.GetGenericTypeDefinition() == genericType ||
												  givenType.BaseType.IsAssignableToGenericType(genericType));
		}

        private static IServiceCollection AddDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicaitonDbContext>(opt => opt.UseSqlite(configuration.GetConnectionString("SqlConnection"),
                                                                             b => b.MigrationsAssembly("Backend.WebApi")));
            AddRepositoryToIoC(services, Assembly.GetExecutingAssembly());
            return services;
        }

        private static IServiceCollection AddMyIdentity(this IServiceCollection services) 
        {
            services.AddIdentityCore<Users>()
               .AddEntityFrameworkStores<ApplicaitonDbContext>()
               .AddDefaultTokenProviders();

            return services;
        }
    }
}
