using AdvWorksAPI.BaseController;
using AdvWorksAPI.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConfigTestController : ControllerBaseApi
{
    private readonly IConfiguration _config;
    private readonly AdvWorksApiDefaults _settings;

    public ConfigTestController(ILogger<ConfigTestController> logger, IConfiguration config, AdvWorksApiDefaults settings)
        : base(logger)
    {
        _config = config;
        _settings = settings;
    }

    [HttpGet]
    [Route("InjectDefaults")]

    public AdvWorksApiDefaults InjectDefaults()
    {
        _settings.InfoMessageDefault = _settings.InfoMessageDefault.Replace("{Verb}", "GET")
            .Replace("{ClassName}", "Product");

        return _settings;
    }

    [HttpGet]
    [Route("IConfigurationTest")]
    public string ConfigurationTest()
    {
        return _config["AdvWorksAPI:InfoMessageDefault"] ?? string.Empty;
    }
    [HttpGet]
    [Route("AssignToClass")]
    public AdvWorksApiDefaults? AssignToClass()
    {
        AdvWorksApiDefaults? settings = _config.GetRequiredSection("AdvWorksAPI").Get<AdvWorksApiDefaults>();

        return settings;


    }


[HttpGet]
    [Route("SetProperties")]
    public AdvWorksApiDefaults SetProperties()
    {
        AdvWorksApiDefaults settings =
            new()
            {
                InfoMessageDefault = _config["AdvWorksAPI:InfoMessageDefault"] ?? string.Empty,
                ProductCategoryID = Convert.ToInt32(_config["AdvWorksAPI:ProductCategoryID"]),
                ProductModelID = Convert.ToInt32(_config["AdvWorksAPI:ProductModelID"]),
            };

        return settings;
    }
}
