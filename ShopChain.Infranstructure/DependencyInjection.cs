using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopChain.Core.Interfaces;
using ShopChain.Infranstructure.Data;
using ShopChain.Infranstructure.Repositories;

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

            services.AddScoped<IStoreRepository, StoreRepository>();
            return services;
        }
    }
}
