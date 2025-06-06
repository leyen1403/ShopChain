using ShopChain.Application;
using ShopChain.Core;
using ShopChain.Infrastructure;

namespace ShopChain.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services
                .AddApplicationDI()
                .AddInfrastructureDI()
                .AddCoreDI();

            //services.AddControllers().AddJsonOptions(options =>
            //{
            //    //options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //});

            return services;
        }
}
}
