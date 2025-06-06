using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Dtos;
using ShopChain.Application.Queries;
using ShopChain.Core.Entities;
using System.Threading.Tasks;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly ISender _sender;

        public StoresController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        /// <summary>
        /// Lấy toàn bộ cửa hàng
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var result = await _sender.Send(new GetAllStoresQuery());
            return Ok(result);
        }

        /// <summary>
        /// Lấy cửa hàng theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var result = await _sender.Send(new GetStoreByIdQuery(id));
            return result is not null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Thêm mới cửa hàng
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] StoreDto storeDto)
        {
            if (storeDto == null) return BadRequest("Thông tin cửa hàng không được để trống");

            var result = await _sender.Send(new AddStoreCommand(storeDto));

            if (result == null)
                return StatusCode(500, "Không thể thêm cửa hàng");

            return CreatedAtAction(nameof(GetStoreById), new { id = result.StoreID }, result);
        }

        /// <summary>
        /// Cập nhật thông tin cửa hàng
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] StoreDto storeDto)
        {
            if (storeDto is null)
            {
                return BadRequest("Thông tin cửa hàng không hợp lệ.");
            }

            var result = await _sender.Send(new UpdateStoreCommand(storeDto));

            return result is not null ? Ok(result) : NotFound();
        }

        /// <summary>
        /// Xóa cửa hàng theo ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _sender.Send(new DeleteStoreCommand(id));
            return result ? NoContent() : NotFound();
        }

        /// <summary>
        /// Lấy danh sách tỉnh/thành
        /// </summary>
        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _sender.Send(new GetAllProvince());
            return Ok(result);
        }

        /// <summary>
        /// Tạo mới danh sách tỉnh dựa trên dữ liệu hiện tại
        /// </summary>
        [HttpPost("provinces")]
        public async Task<IActionResult> CreateProvincesFromData()
        {
            var provinces = await _sender.Send(new GetAllProvince());
            _ = await _sender.Send(new CreateNewProvinceCommand(provinces));
            return Ok();
        }
    }
}
