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
            //var phones = _appDbContext.Phones.ToList();
            var phones = new System.Collections.Generic.List<Data.Domain.Entities.Phone>
            {
                  new Phone
                {
                    Id = new System.Guid("a4cee576-8f90-4dbf-b1b4-9e9761a5976f"),
                    Name = "Pixel 2XL",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                },
                new Phone
                {
                    Id = new System.Guid("755d18ca-2cb5-435c-82b8-60c2639f59df"),
                    Name = "Pixel 4",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                },
                new Phone
                {
                    Id = new System.Guid("c35be0f5-53b5-477c-9bc8-b54c639e6995"),
                    Name = "Iphone 6",
                    ManufacturerId = new System.Guid("eeb2bbef-b79b-4581-8192-4e0e317c062a"),
                    Count = 100
                }
            };
            return View(phones);
        }
    }
}