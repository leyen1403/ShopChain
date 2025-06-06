using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ShopChain.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationDI(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection).Assembly);

            // Đăng ký AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
