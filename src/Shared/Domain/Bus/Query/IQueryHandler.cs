using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace real_state_backend.src.Shared.Domain.Bus.Query
{
    public interface IQueryHandler<TQuery, TResponse> where TQuery : IQuery
    {
        Task<TResponse> Handle(TQuery query);
    }
}