using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Application;
using ShopChain.Core;
using ShopChain.Infrastructure;

namespace ShopChain.Api
{
    /// <summary>
    /// Đăng ký toàn bộ DI của ứng dụng từ các tầng
    /// </summary>
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddApplicationDI()
                .AddInfrastructureDI(configuration)
                .AddCoreDI();
        }
    }
}
