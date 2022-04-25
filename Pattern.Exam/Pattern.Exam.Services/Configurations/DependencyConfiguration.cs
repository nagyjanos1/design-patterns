using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pattern.Exam.Infrastructure.Configurations;
using Pattern.Exam.Services.Implementation;
using Pattern.Exam.Services.Interfaces;

namespace Pattern.Exam.Services.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterServicesDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterInfrastructureDependencies(configuration);

            services.AddScoped<IBasketService, BasketService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddAutoMapper(typeof(MapperConfigurations));
        }
    }
}
