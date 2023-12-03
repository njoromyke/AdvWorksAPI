using AdvWorksAPI.ConstantClasses;
using AdvWorksAPI.EntityLayer;

namespace AdvWorksAPI.ExtensionClasses
{
    public static class WebApplicationBuilderExtensions
    {
        public static void ConfigureGlobalSettings(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<AdvWorksApiDefaults>(builder.Configuration.GetSection("AdvWorksAPI"));

            builder.Services.AddSingleton<AdvWorksApiDefaults,AdvWorksApiDefaults>();
            AdvWorksApiDefaults settings = new();

            builder.Configuration.GetSection(AdvWorksAPIConstants.CorsPolicy).Bind(settings);
            builder.Services.AddSingleton<AdvWorksApiDefaults>(settings);
        }
    }
}
 