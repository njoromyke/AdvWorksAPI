﻿using AdvWorksAPI.BaseController;
using AdvWorksAPI.EntityLayer;
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
    [HttpGet]
    [Route("SetProperties")]
    public AdvWorksApiDefaults SetProperties()
    {
        AdvWorksApiDefaults settings =
            new()
            {
                InfoMessageDefault = _config["AdvWorksAPI:InfoMessageDefault"] ?? string.Empty,
                ProductCategoryID = Convert.ToInt32(_config["AdvWorksAPI:ProductCategoryID"]),
                ProductModelID = Convert.ToInt32(_config["AdvWorksAPI:ProductModelID"])
            };

        return settings;
    }
}
