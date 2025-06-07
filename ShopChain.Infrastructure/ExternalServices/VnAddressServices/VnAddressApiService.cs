using ShopChain.Core.Entities;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.ExternalServices.VnAddressServices.Dtos;
using System.Net.Http.Json;

namespace ShopChain.Infrastructure.ExternalServices.VnAddressServices
{
    public class VnAddressApiService : IVnAddressApiService
    {
        private readonly HttpClient _httpClient;

        public VnAddressApiService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<Province>> GetAllVnAddressAsync(CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ProvinceResponse>>("?depth=3", cancellationToken);

           return response?.Select(p=> new Province
           {
               Code = p.Code,
               Name = p.Name,
               CodeName = p.CodeName,
               DivisionType = p.DivisionType,
               PhoneCode = p.PhoneCode,
               Districts = p.Districts.Select(d => new District
                {
                     Name = d.Name,
                     Code = d.Code,
                     CodeName = d.CodeName,
                     DivisionType = d.DivisionType,
                     ShortCodeName = d.ShortCodeName,
                        Wards = d.Wards.Select(w => new Ward
                        {
                           Name = w.Name,
                           Code = w.Code,
                           CodeName = w.CodeName,
                           DivisionType = w.DivisionType,
                           ShortCodeName = w.ShortCodeName
                        }).ToList()
               }).ToList()
           }).ToList() ?? new List<Province>();
        }
    }
}
