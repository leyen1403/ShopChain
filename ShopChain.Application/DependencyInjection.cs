using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace ShopChain.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            return services;
        }
    }
}
