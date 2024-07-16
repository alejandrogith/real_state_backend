
using real_state_backend.src.Shared.Domain.Bus.Query;
using Real_state_Backend.src.Users.Domain;

namespace real_state_backend.src.Users.Application.Query.FindAll
{
    public class FindQueryHandler : IQueryHandler<FindAllQuery, List<User>>
    {
        private readonly IUserRepository _userRepository;
        public async Task<List<User>> Handle(FindAllQuery query)
        {

            return await _userRepository.FindAll();
        }
    }
}