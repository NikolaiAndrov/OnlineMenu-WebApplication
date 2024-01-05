namespace OnlineMenu.Web.Infrastructure.Extensions
{
	using Microsoft.Extensions.DependencyInjection;
	using System.Reflection;

	/// <summary>
	/// This method registers all services with their Interfaces and Implementations of given Assembly.
	/// The Assembly is taken from a type of random service implementation provided.
	/// </summary>
	public static class WebApplicationBuilderExtensions
	{
		public static void AddApplicationServices(this IServiceCollection services, Type serviceType)
		{
			Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);

			if (serviceAssembly == null)
			{
				throw new InvalidOperationException("Invalid service type!");
			}

			Type[] serviceTypes = serviceAssembly
				.GetTypes()
				.Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
				.ToArray();

			foreach (Type implementationType in serviceTypes)
			{
				Type? interfaceType = implementationType.GetInterface($"I{implementationType.Name}");

				if (interfaceType == null)
				{
					throw new InvalidOperationException($"No interface is provided for the service with name: {implementationType.Name}");
				}

				services.AddScoped(interfaceType, implementationType);
			}
		}
	}
}
