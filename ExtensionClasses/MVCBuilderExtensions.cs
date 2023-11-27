namespace AdvWorksAPI.ExtensionClasses
{
    public static class MVCBuilderExtensions
    {
        public static IMvcBuilder ConfigureJsonOptions(this IMvcBuilder builder)
        {
            return builder
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;
                    options.JsonSerializerOptions.IgnoreReadOnlyProperties = true;
                })
                .AddXmlSerializerFormatters();
        }
    }
}
