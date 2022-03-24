using GroceryStore.Api.Repositories;

namespace GroceryStore.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductJsonRepository>();
        }
    }
}
