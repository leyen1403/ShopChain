using AutoMapper;
using ShopChain.Application.Dtos;
using ShopChain.Core.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShopChain.Application.Mappings
{
    /// <summary>
    /// Cấu hình ánh xạ giữa Entity và DTO
    /// </summary>
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreDto>().ReverseMap();
        }
    }
}
