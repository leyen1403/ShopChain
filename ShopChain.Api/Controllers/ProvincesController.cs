using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly ISender _sender;

        public ProvincesController(ISender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        /// <summary>
        /// Lấy danh sách tỉnh thành từ API ngoài và lưu vào hệ thống
        /// </summary>
        [HttpPost("update-new-store-list")]
        public async Task<IActionResult> UpdateNewStoreList()
        {
            var provinces = await _sender.Send(new GetAllProvince());
            var result = await _sender.Send(new CreateNewProvinceCommand(provinces));
            return Ok(result);
        }

        /// <summary>
        /// Lấy danh sách tỉnh từ API ngoài (không lưu)
        /// </summary>
        [HttpPost("get-new-data")]
        public async Task<IActionResult> GetNewData()
        {
            var provinces = await _sender.Send(new GetAllProvince());
            return Ok(provinces);
        }

        /// <summary>
        /// Lấy toàn bộ tỉnh đã lưu trong hệ thống
        /// </summary>
        [HttpGet("all")]
        public async Task<IActionResult> GetAllProvinces()
        {
            var result = await _sender.Send(new GetAllProvincesQuery());
            return Ok(result);
        }
    }
}
