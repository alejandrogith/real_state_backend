

namespace real_state_backend.src.Shared.Domain.Bus.Query
{
    public class QueryNotRegisteredError : Exception
    {
        public QueryNotRegisteredError(IQuery query) : base(
            $"The query {query} has not a query handler associated")
        {
        }
    }
}