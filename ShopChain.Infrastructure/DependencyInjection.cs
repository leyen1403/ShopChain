using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;
using ShopChain.Infrastructure.Repositories;
using ShopChain.Infrastructure.Services;

namespace ShopChain.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=ShopChain;Integrated Security=True;Trust Server Certificate=True");
            });

            services.AddScoped<IStoreRepository, StoreRepository>();

            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();

            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            services.AddHttpClient<ProvinceHttpClientService>(client =>
            {
                client.BaseAddress = new Uri("https://provinces.open-api.vn/api/");
            });
            return services;
        }
    }
}
