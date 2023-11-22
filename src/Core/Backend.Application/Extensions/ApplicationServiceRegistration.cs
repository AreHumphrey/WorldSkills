﻿using Microsoft.Extensions.DependencyInjection;

namespace Backend.Application.Extensions
{
	public static class ApplicationServiceRegistration
	{
		// Bu projede kullanacağınız servisleri IoC mekanizmasına ekleyecek olan fonksiyondur.
		// This is the function that will add the services you will use in this project to the IoC mechanism.
		public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
		{
			return services;
		}
	}
}
