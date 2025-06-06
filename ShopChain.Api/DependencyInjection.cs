using ShopChain.Application;
using ShopChain.Core;
using ShopChain.Infrastructure;

namespace ShopChain.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddApplicationDI()
                .AddInfrastructureDI(configuration)
                .AddCoreDI();

            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});

            return services;
        }
}
}
