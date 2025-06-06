using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;
using ShopChain.Infrastructure.Repositories;
using ShopChain.Infrastructure.Services;

namespace ShopChain.Infrastructure
{
    /// <summary>
    /// Đăng ký các dependency cho tầng Infrastructure
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            // Đăng ký DbContext với chuỗi kết nối từ cấu hình
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            // Đăng ký Repository
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IExternalVendorRepository, ExternalVendorRepository>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();

            // Đăng ký HttpClient cho gọi API tỉnh thành
            services.AddHttpClient<IProvinceHttpClientService, ProvinceHttpClientService>(client =>
            {
                var baseUrl = configuration["ExternalApis:ProvinceBaseUrl"];
                client.BaseAddress = new Uri(baseUrl ?? "https://provinces.open-api.vn/api/");
            });

            return services;
        }
    }
}
