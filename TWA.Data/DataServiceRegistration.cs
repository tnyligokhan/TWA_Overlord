using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TWA.Core.Interfaces;
using TWA.Data.Context;
using TWA.Data.Repositories;

namespace TWA.Data
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, IConfiguration configuration)
        {
            // SQL Server Bağlantısı
            services.AddDbContext<TwaDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("TWA.Data")));

            // UnitOfWork ve Repository Kaydı
            // Scoped: Her HTTP isteği için yeni bir tane oluşturur.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
