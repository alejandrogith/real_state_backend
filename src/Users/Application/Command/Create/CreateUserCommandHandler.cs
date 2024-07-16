

using System.Text.Json;
using real_state_backend.src.Shared.Domain.Bus.Command;
using real_state_backend.src.Users.Domain;
using Real_state_Backend.src.Users.Domain;

namespace real_state_backend.src.Users.Application.Command.Create
{
    public class CreateUserCommandHandler : ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand command)
        {
            var id = new UserId(command.Id);
            var email = new UserEmail(command.Email);
            var name = new UserName(command.Name);

            var user = User.Create(id, email, name);

            await _userRepository.Save(user);
        }
    }
}