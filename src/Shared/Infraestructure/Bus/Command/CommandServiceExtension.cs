
using System.Reflection;

using real_state_backend.src.Shared.Domain.Bus.Command;

namespace real_state_backend.src.Shared.Infraestructure.Bus.Command
{
    public static class CommandServiceExtensions
    {
        public static IServiceCollection AddCommandServices(this IServiceCollection services)
        {
            var classTypes = Assembly.GetExecutingAssembly()
                                     .ExportedTypes.Select(t => t.GetTypeInfo())
                                     .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(x => x.IsGenericType));

            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerInterfaceType in interfaces.Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)))
                    services.AddScoped(handlerInterfaceType.AsType(), type.AsType());
            }

            services.AddScoped<ICommandBus, InMemoryCommandBus>();
            return services;
        }
    }
}