using Backend.Infrastructure.Email;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;


namespace Backend.Infrastructure.Extensions
{
	public static class InfrastructureServiceRegistration
	{
		// Bu projede kullanacağınız servisleri IoC mekanizmasına ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddInfrastructureServiceRegistration(this IServiceCollection services)
		{
			services.AddEmailSender();

            return services;
		}

		public static IServiceCollection AddEmailSender(this IServiceCollection services)
		{
			services.AddTransient<IEmailSender, EmailSender>();
			return services;
		}
	}
}
