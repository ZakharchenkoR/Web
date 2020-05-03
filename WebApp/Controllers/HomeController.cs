using System.Linq;
using Data.Domain.DataContext;
using Data.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public HomeController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            var phones = _appDbContext.Phones.ToList();
            return View(phones);
        }
    }
}