using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace API.Extensions
{

    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
            options.TokenValidationParameters = new TokenValidationParameters
                {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding
                .UTF8.GetBytes(config["TokenKey"])),
                ValidateIssuer = false, 
                ValidateAudience = false,
                };
            }); // this gives our server enough info to look at the token, and validate it based on the issuer signin key
            
            return services; // In order to use all this, we go back to Program.cs, and say 'builder.Services.AddApplicationServices(builder.Configuration);'
        }
    }
}