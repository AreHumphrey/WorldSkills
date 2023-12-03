using Backend.Application.Abstractions.Repositories.Common;
using Backend.Application.Extensions;
using Backend.Persistence.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;

namespace Backend.Persistence.Extensions
{
	public static class PersistenceServiceRegistration
	{
		// Bu projede kullanaca��n�z servisleri IoC mekanizmas�na ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDb(configuration);
            services.AddJwt(configuration);

            return services;
		}

        private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes
                        (configuration["Jwt:Key"]))
                    };
                });

            return services;
        }

        // Repository lerin otomatik olarak IoC Container a eklenmesini sa�layan metod
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


		//Type in verilen generic t�rden t�reyip t�remedi�ini kontrol eden fonksiyon
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
	}
}