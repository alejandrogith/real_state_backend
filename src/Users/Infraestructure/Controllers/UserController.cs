
using Microsoft.AspNetCore.Mvc;
using real_state_backend.src.Shared.Domain.Bus.Command;
using real_state_backend.src.Shared.Domain.Bus.Query;
using real_state_backend.src.Users.Application.Command.Create;
using real_state_backend.src.Users.Application.Query.FindAll;




namespace Real_state_Backend.src.User.Infraestructure.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {

        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public UserController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Users.Domain.User), StatusCodes.Status200OK)]
        public async Task<IActionResult> FindAll()
        {

            var response = await _queryBus.Send<List<Users.Domain.User>>(new FindAllQuery());

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Save([FromBody] CreateUserCommand command)
        {
            await _commandBus.Send(command);

            return CreatedAtAction(nameof(Save), null);
        }
    }




}