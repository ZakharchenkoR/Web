using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace WebApp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public AccountController()
        {
          
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
     
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl)
        {
           
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            
        }
    }
}