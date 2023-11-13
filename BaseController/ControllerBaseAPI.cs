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
       
    }
}
