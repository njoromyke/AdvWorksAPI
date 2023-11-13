using AdvWorksAPI.BaseController;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfigTestController : ControllerBaseApi
{
    private readonly IConfiguration _config;

    public ConfigTestController(ILogger<ConfigTestController> logger, IConfiguration config)
        : base(logger)
    {
        _config = config;
    }

    [HttpGet]
    [Route("IConfigurationTest")]
    public string ConfigurationTest()
    {
        return _config["AdvWorksAPI:InfoMessageDefault"] ?? string.Empty;
    }
}
