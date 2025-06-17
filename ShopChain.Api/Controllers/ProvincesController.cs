using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;
using ShopChain.Application.Queries.ProvinceQueries;

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

        /// <summary>
        /// Đông bộ dữ liệu tỉnh/thành từ API
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpPost("sync")]
        public async Task<IActionResult> Sync()
        {
            var count = await _sender.Send(new SyncLocationsCommand());
            return Ok(new { message = $"Đồng bộ thành công {count} tỉnh/thành." });
        }

        /// <summary>
        /// Lấy danh sách tất cả tỉnh/thành đã lưu trong hệ thống (bao gồm quận/huyện, phường/xã)
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-all-provinces")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var provinces = await _sender.Send(new GetAllProvincesQuery());
            return Ok(provinces);
        }

        /// <summary>
        /// Lấy danh sách tên tất cả tỉnh/thành đã lưu trong hệ thống
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-all-province-names")]
        public async Task<IActionResult> GetAllProvinceNames()
        {
            var provinceNames = await _sender.Send(new GetAllProvinceName());
            return Ok(provinceNames);
        }

        /// <summary>
        /// Lấy danh sách tên quận/huyện theo tên tỉnh
        /// </summary>
        /// <param name="name">Tên tỉnh/thành phố</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-all-district-by-province-name/{name}")]
        public async Task<IActionResult> GetAllDistrictByProvinceName(string name)
        {
            var districts = await _sender.Send(new GetAllDistrictByProvinceNameQuery(name));
            return Ok(districts);
        }

        /// <summary>
        /// Lấy danh sách tên phường/xã theo tên quận/huyện
        /// </summary>
        /// <param name="name">Tên quận/huyện</param>
        /// <returns></returns>
        [Authorize]
        [HttpGet("get-all-ward-by-district-name/{name}")]
        public async Task<IActionResult> GetAllWardByDistrictName(string name)
        {
            var wards = await _sender.Send(new GetAllWardByDistrictNameQuery(name));
            return Ok(wards);
        }
    }
}
