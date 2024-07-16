

namespace real_state_backend.src.Shared.Domain.Bus.Query
{
    public interface IQueryBus
    {
        Task<TResponse> Send<TResponse>(IQuery request);
    }
}