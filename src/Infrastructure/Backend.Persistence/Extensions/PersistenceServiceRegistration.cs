using Backend.Application.Abstractions.Repositories.Common;
using Backend.Application.Extensions;
using Backend.Persistence.Context;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using React.AspNet;
using System.Reflection;
using JavaScriptEngineSwitcher.ChakraCore;

namespace Backend.Persistence.Extensions
{
	public static class PersistenceServiceRegistration
	{
		// Bu projede kullanacaðýnýz servisleri IoC mekanizmasýna ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDb(configuration);
            services.AddJwt(configuration);
            services.AddMyCors(configuration);
            services.AddMyReact();

            return services;
		}

        private static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    string s = configuration["Jwt:Key"];
                    if (s == null)
                        s = "morderboy.ru";

                    Console.WriteLine("Jwt:Key value: {0}", s);
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["Jwt:Issuer"],
                        ValidAudience = configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            System.Text.Encoding.UTF8.GetBytes(s))
                    };
                });

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

        private static IServiceCollection AddMyCors(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddCors(options =>
            options.AddPolicy("AllAllow", policy =>
                {
                    policy.AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowAnyOrigin();
                })
            );

            return services;
        }

        private static IServiceCollection AddMyReact(this IServiceCollection services) 
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();

            return services;
        }
	}
}
