using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using real_state_backend.src.Shared.Domain.Bus.Query;

namespace real_state_backend.src.Shared.Infraestructure.Bus.Query
{
    public static class QueryServiceExtension
    {
        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {

            var classTypes = Assembly.GetExecutingAssembly()
                                     .ExportedTypes.Select(t => t.GetTypeInfo())
                                     .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(x => x.IsGenericType));


            foreach (var type in classTypes)
            {
                var interfaces = type.ImplementedInterfaces.Select(i => i.GetTypeInfo());

                foreach (var handlerInterfaceType in interfaces.Where(i =>
                    i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
                    services.AddScoped(handlerInterfaceType.AsType(), type.AsType());
            }

            services.AddScoped<IQueryBus, InMemoryQueryBus>();

            return services;
        }
    }
}