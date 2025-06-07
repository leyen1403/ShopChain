using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : BaseApiController
    {
        private readonly ISender _sender;

        public ProvincesController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        [HttpPost("sync")]
        public async Task<IActionResult> Sync()
        {
            var count = await _sender.Send(new SyncLocationsCommand());
            return Ok(new { message = $"Đồng bộ thành công {count} tỉnh/thành." });
        }

    }
}
