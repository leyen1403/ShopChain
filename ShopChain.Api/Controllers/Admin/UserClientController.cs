using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands.UserClientCommands;

namespace ShopChain.Api.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserClientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserClientController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        /// <summary>
        /// Đăng ký tài khoản client mới
        /// </summary>
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserClientRequest request, CancellationToken cancellationToken)
        {
            // request: chứa Username, Password, FullName
            var command = new RegisterUserClientCommand(request);

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(Register), new { username = result.Value!.Username }, result.Value);
            }
            else
            {
                return BadRequest(new { error = result.Error });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserClientRequest request, CancellationToken cancellationToken)
        {
            var command = new LoginUserClientCommand(request);

            var result = await _mediator.Send(command, cancellationToken);

            if (!result.IsSuccess)
                return BadRequest(new { result.Error });

            return Ok(result.Value);
        }
    }
}
