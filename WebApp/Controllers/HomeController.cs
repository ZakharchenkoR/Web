using DomainServices.Common;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly IDataManager _dataManager;

        public HomeController(IDataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _dataManager.ModelRepository.GetModelsAsync();
            return View(items);
        }
    }
}