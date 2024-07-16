

namespace real_state_backend.src.Shared.Domain.Bus.Query
{
    internal abstract class QueryHandlerWrapper<TResponse>
    {
        public abstract Task<TResponse> Handle(IQuery query, IServiceProvider provider);
    }

    internal class QueryHandlerWrapper<TQuery, TResponse> : QueryHandlerWrapper<TResponse>
        where TQuery : IQuery
    {
        public override async Task<TResponse> Handle(IQuery query, IServiceProvider provider)
        {
            var handler =
                (IQueryHandler<TQuery, TResponse>)provider.GetService(typeof(IQueryHandler<TQuery, TResponse>));

            return await handler.Handle((TQuery)query);
        }
    }
}