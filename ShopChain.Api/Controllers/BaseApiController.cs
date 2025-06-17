using Microsoft.AspNetCore.Mvc;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected IActionResult ErrorResponse(int statusCode, string title, string message)
        {
            return StatusCode(statusCode, new
            {
                status = statusCode,
                title,
                message
            });
        }
    }
}
