
using System.Collections;
using System.Collections.Concurrent;

using real_state_backend.src.Shared.Domain.Bus.Query;

namespace real_state_backend.src.Shared.Infraestructure.Bus.Query
{
    public class InMemoryQueryBus : IQueryBus
    {
        private static readonly ConcurrentDictionary<Type, object> _queryHandlers =
            new ConcurrentDictionary<Type, object>();

        private readonly IServiceProvider _provider;

        public InMemoryQueryBus(IServiceProvider provider)
        {
            _provider = provider;
        }

        public async Task<TResponse> Send<TResponse>(IQuery query)
        {
            var handler = GetWrappedHandlers<TResponse>(query);

            if (handler == null) throw new QueryNotRegisteredError(query);

            return await handler.Handle(query, _provider);
        }

        private QueryHandlerWrapper<TResponse> GetWrappedHandlers<TResponse>(IQuery query)
        {
            Type[] typeArgs = { query.GetType(), typeof(TResponse) };

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(typeArgs);
            var wrapperType = typeof(QueryHandlerWrapper<,>).MakeGenericType(typeArgs);

            var handlers =
                (IEnumerable)_provider.GetService(typeof(IEnumerable<>).MakeGenericType(handlerType));

            var wrappedHandlers = (QueryHandlerWrapper<TResponse>)_queryHandlers.GetOrAdd(query.GetType(),
                handlers.Cast<object>()
                    .Select(handler => (QueryHandlerWrapper<TResponse>)Activator.CreateInstance(wrapperType))
                    .FirstOrDefault());

            return wrappedHandlers;
        }
    }
}