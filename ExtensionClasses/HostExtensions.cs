using Serilog;
using Serilog.Events;

namespace AdvWorksAPI.ExtensionClasses
{
    public static class HostExtensions
    {
        public static IHostBuilder ConfigureSeriLog(this IHostBuilder host)
        {
            return host.UseSerilog(
                (ctx, lc) =>
                {
                    lc.WriteTo.Console();

                    //Logging to Rolling File
                    lc.WriteTo.File(
                        "Logs/InfoLog-.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Information
                    );
                    lc.WriteTo.File(
                        "Logs/ErrorLog-.txt",
                        rollingInterval: RollingInterval.Day,
                        restrictedToMinimumLevel: LogEventLevel.Error
                    );
                }
            );
        }
    }
}
