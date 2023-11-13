using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.BaseController
{
    public class ControllerBaseApi : ControllerBase
    {
        protected readonly ILogger Logger;

        public ControllerBaseApi(ILogger logger)
        {
            Logger = logger;
            InfoMessage = string.Empty;
            ErrorLogMessage = string.Empty;

        }

        public string InfoMessage { get;set; }
        public string ErrorLogMessage { get;set; }

        protected ActionResult<T> HandleException<T>(Exception ex, string infoMessage, string errorMessage)
        {
            InfoMessage = infoMessage;
            ErrorLogMessage = errorMessage;

            return HandleException<T>(ex);
        }

        protected ActionResult<T> HandleException<T>(Exception ex)
        {
            ActionResult<T> ret = StatusCode(StatusCodes.Status500InternalServerError, InfoMessage);

            ErrorLogMessage += $"{Environment.NewLine} Message: {ex.Message}";
            ErrorLogMessage += $"{Environment.NewLine} Source: {ex.Source}";
            ErrorLogMessage += $"{Environment.NewLine} Stack Trace: {ex.StackTrace}";

            Logger.LogError(ex, "{ErrorLogMessage}",ErrorLogMessage);

            return ret;
        }
       
    }
}
