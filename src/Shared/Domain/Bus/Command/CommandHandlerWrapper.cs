

namespace real_state_backend.src.Shared.Domain.Bus.Command
{
    internal abstract class CommandHandlerWrapper
    {
        public abstract Task Handle(ICommand command, IServiceProvider provider);
    }

    internal class CommandHandlerWrapper<TCommand> : CommandHandlerWrapper
        where TCommand : ICommand
    {
        public override async Task Handle(ICommand domainEvent, IServiceProvider provider)
        {
            var handler = (ICommandHandler<TCommand>)provider.GetService(typeof(ICommandHandler<TCommand>));
            await handler.Handle((TCommand)domainEvent);
        }
    }
}