using Microsoft.Extensions.DependencyInjection;

namespace AdministracionHotelesLocales.Infra.Extensions
{
    public static class ServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection svc)
        {
            var _services = AppDomain.CurrentDomain.GetAssemblies()
                .Where(assembly => {
                    return assembly.FullName is not null && assembly.FullName.Contains("AdministracionHotelesLocales.Domain", StringComparison.InvariantCulture);
                })
                .SelectMany(s => s.GetTypes())
                .Where(p => p.CustomAttributes.Any(x => x.AttributeType == typeof(Domain.Services.DomainServiceAttribute)));

            foreach (var _service in _services)
            {
                svc.AddTransient(_service);
            }

            return svc;
        }
    }
}
