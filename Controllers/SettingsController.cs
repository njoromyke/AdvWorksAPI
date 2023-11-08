using AdvWorksAPI.EntityLayer;
using Microsoft.AspNetCore.Mvc;

namespace AdvWorksAPI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly AdvWorksApiDefaults _settings;

        public SettingsController(AdvWorksApiDefaults settings)
        {
            _settings = settings;
        }

        [HttpGet]
        [Route("GetSettings")]

        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AdvWorksApiDefaults> GetSettings()
        {
            return Ok(_settings);
        } 
        
        [HttpGet]
        [Route("GetSettingsAgain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<AdvWorksApiDefaults> GetSettingsAgain()
        {
            return Ok(_settings);
        }
    }
}
