using AdvWorksAPI.ConstantClasses;

namespace AdvWorksAPI.ExtensionClasses
{
    public static class ServiceExtensions
    {
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
