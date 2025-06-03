using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;
using ShopChain.Core.Entities;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var result = await sender.Send(new GetAllStore());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var result = await sender.Send(new GetStoreByID(id));
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] Store store)
        {
            var result = await sender.Send(new AddStoreCommand(store));
            return CreatedAtAction(nameof(GetStoreById), new { id = result.StoreID }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] Store store)
        {
            var result = await sender.Send(new UpdateStoreCommand(store));
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {            
            var result = await sender.Send(new DeleteStoreCommand(id));
            return result ? NoContent() : NotFound();
        }
    }
}
