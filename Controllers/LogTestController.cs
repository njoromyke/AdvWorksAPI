using AdvWorksAPI.BaseController;
using AdvWorksAPI.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LogTestController : ControllerBaseApi
{
    public LogTestController(ILogger<LogTestController> logger)
        : base(logger) { }

    [HttpGet]
    [Route("WriteMessages")]
    public string WriteMessages()
    {
        WriteLogMessages();

        return "Check your Console Window or the Log File";
    }

    private void WriteLogMessages()
    {
        Logger.LogTrace("This is a log entry");
        Logger.LogDebug("This is a debug log entry");
        Logger.LogInformation("This is an information log entry");
        Logger.LogWarning("This is a warning log entry");
        Logger.LogError("This is an error log entry");
        Logger.LogError("This is an error log entry");
        Logger.LogCritical("This is a critical log");
    }

    [HttpGet]
    [Route("LogObject")]
    public string LogObject()
    {
        LogProduct();

        return "Check Console or Log File";
    }

    private void LogProduct()
    {
        Product entity = new Product()
        {
            ProductID = 999,
            Name = "Test Product",
            StandardCost = 3445,
            ListPrice = 2400,
            Color = "Black",
            Size = "LG",
            ProductNumber = "TEST NUMBER"
        };

        string json = base.SerializeEntity<Product>(entity);
        Logger.LogInformation("Product ={json}", json);
    }
}
