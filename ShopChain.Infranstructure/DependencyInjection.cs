using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Core.Interfaces;
using ShopChain.Infranstructure.Data;
using ShopChain.Infranstructure.Repositories;
using ShopChain.Infranstructure.Services;

namespace ShopChain.Infranstructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfranstructureDI(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer("Data Source=.;Initial Catalog=ShopChain;Integrated Security=True;Trust Server Certificate=True");
            });

            services.AddScoped<IStoreRepository, FormatProvider>();

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
