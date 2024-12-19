using MDS.DbContext.Infrastructure;
using MDS.Infrastructure.DbUtility;
using MDS.Infrastructure.Services;
using MDS.Infrastructure.Settings;
using MDS.Services.Email.Implementation;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Reflection;

namespace MDS.Api.Utility.Extensions
{
    public static class RegisterServicesExtention
    {
        public static IServiceCollection AddUnitOfWork(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped)
        {
            services.TryAddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
        public static IServiceCollection AddUnitOfWork<T>(this IServiceCollection services, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where T : Microsoft.EntityFrameworkCore.DbContext
        {
            services.TryAddScoped<IUnitOfWork<T>, UnitOfWork<T>>();
            return services;
        }
        public static void RegisterUtilityServices_depricated(this IServiceCollection services, IConfiguration configuration)
        {
            var bloggingContext = ApplicationDbContext.Create(configuration.GetConnectionString("DefaultConnection"));
            services.AddSingleton<IUnitOfWork>(x => new UnitOfWork(bloggingContext));
        }
        public static void AutoRegisterServices(this IServiceCollection services)
        {
            var appSettingsAssemblies = GetAppSettingsInjectableAssemblies();
            foreach (var assembly in appSettingsAssemblies)
            {
                RegisterAppSettingsFromAssembly(services, assembly);
            }

            var servicesAssemblies = GetServicesInjectableAssemblies();
            foreach (var assembly in servicesAssemblies)
            {
                RegisterBloggingServicesFromAssembly(services, assembly);
            }
        }
        private static IEnumerable<Assembly> GetAppSettingsInjectableAssemblies()
        {
            yield return Assembly.GetAssembly(typeof(IAppSettings)); // Infrastructure
        }
        private static IEnumerable<Assembly> GetServicesInjectableAssemblies()
        {
            yield return Assembly.GetAssembly(typeof(EmailService)); // Services
        }
        private static bool IsInjectable(Type t)
        {
            var interfaces = t.GetInterfaces();
            var injectable = interfaces.Any(i =>
                i.IsAssignableFrom(typeof(IService))
            );
            return injectable;
        }
        private static void RegisterAppSettingsFromAssembly(IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (type.Name.EndsWith("Settings"))
                {
                    services.AddSingleton(type, typeof(AppSettings));
                }
            }
        }
        private static void RegisterBloggingServicesFromAssembly(IServiceCollection services, Assembly assembly)
        {
            foreach (var type in assembly.GetTypes())
            {
                if (typeof(IService).IsAssignableFrom(type))
                {
                    var childTypes =
                        type.Assembly
                            .GetTypes()
                            .Where(t => t.IsClass && t.GetInterface(type.Name) != null);

                    foreach (var childType in childTypes)
                    {
                        services.AddScoped(type, childType);
                    }
                }
            }
        }
    }
}
