using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Pattern.Exam.Infrastructure.Configurations
{
    public static class DependencyConfiguration
    {
        public static void RegisterInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WebShopDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("WebShopDatabase")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
