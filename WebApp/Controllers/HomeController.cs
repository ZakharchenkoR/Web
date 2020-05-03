using Microsoft.AspNetCore.Mvc;
using Services.Common;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _serviceManager.PhoneService.GetPhoneModelsAsync();
            return View(items);
        }
    }
}