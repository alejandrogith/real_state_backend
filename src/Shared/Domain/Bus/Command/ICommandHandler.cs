

namespace real_state_backend.src.Shared.Domain.Bus.Command
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command);
    }
}