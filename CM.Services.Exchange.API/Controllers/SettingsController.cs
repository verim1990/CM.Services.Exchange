using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CM.Services.Exchange.API.Controllers
{
    [Route("settings")]
    public class SettingsController : Controller
    {
        private readonly IOptionsSnapshot<AppSettings> _appSettings;

        public SettingsController(IOptionsSnapshot<AppSettings> appSettings)
        {
            _appSettings = appSettings;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("")]
        public IActionResult Index()
        {
            return Json(_appSettings.Value.GetPublicSettings());
        }
    }
}