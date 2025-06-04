using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController(ISender sender) : ControllerBase
    {
        [HttpPost("UpdateNewStoreList")]
        public async Task<IActionResult> UpdateNewStoreList()
        {
            var model = await sender.Send(new GetAllProvince());
            var entity = await sender.Send(new CreateNewProvinceCommand(model));
            return Ok();
        }

        [HttpPost("GetNewData")]
        public async Task<IActionResult> GetNewData()
        {
            var model = await sender.Send(new GetAllProvince());
            return Ok(model);
        }

        [HttpGet("GetAllProvinces")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var result = await sender.Send(new GetAllProvincesQuery());
            return Ok(result);
        }
    }
}
