using Microsoft.EntityFrameworkCore;
using ShopChain.Core.Interfaces;
using ShopChain.Infranstructure.Data;

namespace ShopChain.Infranstructure.Repositories
{
    public class ProvinceRepository(AppDbContext context) : IProvinceRepository
    {
        public async Task<List<ShopChain.Core.Entities.Province>> CreateNewProvince(List<ShopChain.Core.Models.Province> provinces)
        {
            if (provinces == null || !provinces.Any())
            {
                throw new ArgumentException("Provinces list cannot be null or empty.", nameof(provinces));
            }
            context.Wards.RemoveRange(context.Wards);
            context.Districts.RemoveRange(context.Districts);
            context.Provinces.RemoveRange(context.Provinces);
            var entityList = provinces.Select(model => new ShopChain.Core.Entities.Province
            {
                Name = model.Name,
                CodeName = model.CodeName,
                DivisionType = model.DivisionType,
                PhoneCode = model.PhoneCode,
                Districts = model.Districts.Select(d => new ShopChain.Core.Entities.District
                {
                    Name = d.Name,
                    CodeName = d.CodeName,
                    DivisionType = d.DivisionType,
                    ShortCodeName = d.ShortCodeName,
                    ProvinceCode = model.Code,
                    Wards = d.Wards.Select(w => new ShopChain.Core.Entities.Ward
                    {
                        Name = w.Name,
                        CodeName = w.CodeName,
                        DivisionType = w.DivisionType,
                        ShortCodeName = w.ShortCodeName,
                        DistrictCode = d.Code
                    }).ToList()
                }).ToList()
            }).ToList();

            context.Provinces.AddRange(entityList);

            await context.SaveChangesAsync();

            return entityList;
        }

        public async Task<List<ShopChain.Core.Entities.Province>> GetAllProvinces()
        {
            return await context.Provinces
                .Include(p => p.Districts)
                    .ThenInclude(d => d.Wards)
                .ToListAsync();
        }
    } 
}
