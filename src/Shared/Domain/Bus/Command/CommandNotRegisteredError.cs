using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace real_state_backend.src.Shared.Domain.Bus.Command
{
    public class CommandNotRegisteredError : Exception
    {
        public CommandNotRegisteredError(ICommand command) : base(
             $"The command {command} has not a command handler associated")
        {
        }
    }
}