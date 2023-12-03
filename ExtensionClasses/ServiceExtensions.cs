using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer;
using AdvWorksAPI.Interfaces;
using AdvWorksAPI.RepositoryLayer;

namespace AdvWorksAPI.ExtensionClasses
{
    public static class ServiceExtensions
    {

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
