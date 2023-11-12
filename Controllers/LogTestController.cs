using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;


[Route("api/[controller]")]
[ApiController]
public class LogTestController : ControllerBase
{

    private readonly ILogger<LogTestController> _logger;

        public LogTestController (ILogger<LogTestController> logger)
        {
            _logger = logger;
          
        }

        [HttpGet]
        [Route("WriteMessages")]

        public string WriteMessages()
        {
            WriteLogMessages();

            return "Check your Console Window";
        }

        private void WriteLogMessages()
        {
            _logger.LogTrace("This is a log entry");
            _logger.LogDebug("This is a debug log entry");
            _logger.LogInformation("This is an information log entry");
            _logger.LogWarning("This is a warning log entry");
            _logger.LogError("This is an error log entry");
            _logger.LogError("This is an error log entry");
            _logger.LogCritical( "This is a critical log");
        }

    }

