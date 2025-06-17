using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Dtos;
using ShopChain.Application.Queries.UserClientQueries;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly ISender _sender;

        public AuthController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var token = await _sender.Send(new GetTokenQuery(request.Username, request.Password));
            return Ok(token); // Wrap the string token in an Ok() result to return it as IActionResult
        }
    }
}
