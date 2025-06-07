using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Core.Interfaces;
using ShopChain.Infrastructure.Data;
using ShopChain.Infrastructure.ExternalServices.VnAddressServices;
using ShopChain.Infrastructure.Repositories;


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
            services.AddScoped<IVnAddressApiService, VnAddressApiService>();
            services.AddScoped<IProvinceRepository, ProvinceRepository>();
            services.AddScoped<ILocationRepository, LocationRepository>();

            // Đăng ký HttpClient cho gọi API tỉnh thành
            services.AddHttpClient<IVnAddressApiService, VnAddressApiService>(client =>
            {
                var baseUrl = configuration["ExternalApis:ProvinceBaseUrl"];
                client.BaseAddress = new Uri(baseUrl ?? "https://provinces.open-api.vn/api/");
            });

            return services;
        }
    }
}
