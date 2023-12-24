using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;
using Microsoft.AspNetCore.Authentication;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace AdvWorksAPI.ExtensionClasses
{
    public static class ServiceExtensions
    {
        public static AuthenticationBuilder ConfigureJwtAuthentication(this IServiceCollection services, AdvWorksApiDefaults settings)
        {
            return services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.TokenValidationParameters
                    = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = settings.JWTSettings.Issuer,
                        ValidateAudience = true,
                        ValidAudience = settings.JWTSettings.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.JWTSettings.Key)),
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(settings.JWTSettings.MinutesToExpiration)
                    };
            });

        }

        public static IServiceCollection ConfigureJwtAuthorization(this IServiceCollection services)
        {
            return services.AddAuthorization();
        }

        public static void AddRepositoryClasses(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Product>, ProductRepository>();
        }
        public static IServiceCollection ConfigureCors(this IServiceCollection services)
        {
            return services.AddCors(options =>
            {
                options.AddPolicy(AdvWorksAPIConstants.CorsPolicy, builder =>
                {
                    // builder.AllowAnyOrigin();
                    builder.WithOrigins("http://localhost:5126", "http://ww.example.com");
                    //builder.WithOrigins("http://localhost:5126", "http://ww.example.com").AllowAnyMethod();
                    //builder.WithOrigins("http://localhost:5126", "http://ww.example.com").WithMethods("GET", "POST", "PUT");

                });
            });
        }
    }
}
