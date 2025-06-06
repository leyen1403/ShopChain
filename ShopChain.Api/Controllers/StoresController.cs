using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Dtos;
using ShopChain.Application.Queries;
using ShopChain.Core.Entities;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    public class StoresController : BaseApiController
    {
        private readonly ISender _sender;

        public StoresController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        /// <summary>
        /// Lấy danh sách tất cả cửa hàng
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var result = await _sender.Send(new GetAllStoresQuery());
            return Ok(result);
        }

        /// <summary>
        /// Lấy thông tin cửa hàng theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var result = await _sender.Send(new GetStoreByIdQuery(id));
            return result is not null
                ? Ok(result)
                : ErrorResponse(404, "Không tìm thấy", $"Không có cửa hàng với ID = {id}");
        }

        /// <summary>
        /// Tạo mới cửa hàng
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> CreateStore([FromBody] StoreDto storeDto)
        {
            if (storeDto is null)
                return ErrorResponse(400, "Dữ liệu không hợp lệ", "Thông tin cửa hàng không được để trống.");

            var result = await _sender.Send(new AddStoreCommand(storeDto));

            return result is not null
                ? CreatedAtAction(nameof(GetStoreById), new { id = result.StoreID }, result)
                : ErrorResponse(500, "Lỗi hệ thống", "Không thể thêm cửa hàng vào hệ thống.");
        }

        /// <summary>
        /// Cập nhật cửa hàng
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateStore([FromBody] StoreDto storeDto)
        {
            if (storeDto is null)
                return ErrorResponse(400, "Dữ liệu không hợp lệ", "Thông tin cửa hàng không hợp lệ.");

            var result = await _sender.Send(new UpdateStoreCommand(storeDto));

            return result is not null
                ? Ok(result)
                : ErrorResponse(404, "Không tìm thấy", $"Không có cửa hàng với ID = {storeDto.StoreID}");
        }

        /// <summary>
        /// Xóa mềm cửa hàng theo ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStore(int id)
        {
            var result = await _sender.Send(new DeleteStoreCommand(id));
            return result
                ? NoContent()
                : ErrorResponse(404, "Không tìm thấy", $"Không thể xóa cửa hàng với ID = {id}");
        }

        /// <summary>
        /// Lấy danh sách tỉnh/thành từ API ngoài
        /// </summary>
        [HttpGet("provinces")]
        public async Task<IActionResult> GetProvinces()
        {
            var result = await _sender.Send(new GetAllProvince());
            return Ok(result);
        }

        /// <summary>
        /// Đồng bộ và lưu danh sách tỉnh/thành vào hệ thống
        /// </summary>
        [HttpPost("provinces")]
        public async Task<IActionResult> CreateProvincesFromData()
        {
            var provinces = await _sender.Send(new GetAllProvince());
            await _sender.Send(new CreateNewProvinceCommand(provinces));
            return Ok(new { message = "Cập nhật danh sách tỉnh/thành thành công." });
        }
    }
}
