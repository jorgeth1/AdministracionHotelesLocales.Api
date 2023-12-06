using AdministracionHotelesLocales.Domain.Ports.Repositories;
using AdministracionHotelesLocales.Infra.Adapters;
using AdministracionHotelesLocales.Infra.Ports;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AdministracionHotelesLocales.Infra.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistence(this IServiceCollection svc, IConfiguration config)
        {
            svc.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            svc.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));

            var repositories = AppDomain.CurrentDomain.GetAssemblies().Where(assembly =>
            {
                return assembly.FullName is not null && assembly.FullName.Contains("AdministracionHotelesLocales.Infra", StringComparison.InvariantCulture);
            }).
            SelectMany(repo => repo.GetTypes())
            .Where(properties => properties.CustomAttributes.Any(customProperty => customProperty.AttributeType == typeof(RepositoryAttribute)));

            foreach (Type repo in repositories)
            {
                svc.AddTransient(repo.GetInterfaces().First(), repo);
            }

            return svc;
        }

    }
}

