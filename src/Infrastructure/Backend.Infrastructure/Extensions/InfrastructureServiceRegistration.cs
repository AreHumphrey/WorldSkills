using Backend.Infrastructure.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Http;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using React.AspNet;


namespace Backend.Infrastructure.Extensions
{
	public static class InfrastructureServiceRegistration
	{
		// Bu projede kullanacağınız servisleri IoC mekanizmasına ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddEmailSender();
            services.AddJwt(configuration);
            services.AddMyCors();
            services.AddMyReact();

            return services;
		}

		public static IServiceCollection AddEmailSender(this IServiceCollection services)
		{
			services.AddTransient<IEmailSender, EmailSender>();
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

        private static IServiceCollection AddMyCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            options.AddPolicy("AllAllow", policy =>
            {
                policy.AllowAnyHeader()
                      .AllowAnyMethod()
                      .WithOrigins("http://localhost:3000/*",
                                   "https://morderboy.ru/")
                      .AllowCredentials();
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
