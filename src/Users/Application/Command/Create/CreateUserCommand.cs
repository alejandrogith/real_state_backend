

using real_state_backend.src.Shared.Domain.Bus.Command;

namespace real_state_backend.src.Users.Application.Command.Create
{
    public class CreateUserCommand : ICommand
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }



    }
}