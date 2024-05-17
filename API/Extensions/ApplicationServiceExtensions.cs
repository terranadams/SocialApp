using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions 
{
    public static class ApplicationServiceExtensions // 'status' means we can use the methods inside it without creating a new instance of the class
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            // Add the data context for Entity Framework Core, configuring it to use SQLite
            // with a connection string from the app settings.
            services.AddDbContext<DataContext>(opt => 
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            // Add Cross-Origin Resource Sharing (CORS) services to the service collection.
            // This allows your API to be called from different domains, which is particularly
            // useful during development.
            services.AddCors();

            // Register the token service with dependency injection making it available
            // for controller constructors and other services.
            services.AddScoped<ITokenService, TokenService>();

            return services; // In order to use all this, we go back to Program.cs, and say 'builder.Services.AddApplicationServices(builder.Configuration);'
        }
    }
}

