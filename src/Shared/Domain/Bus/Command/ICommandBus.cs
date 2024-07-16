

namespace real_state_backend.src.Shared.Domain.Bus.Command
{
    public interface ICommandBus
    {
        Task Send(ICommand command);
    }
}