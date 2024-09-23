using Microsoft.AspNetCore.Mvc;

namespace Comapany.G02.Pl.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult SignUp()
        {
            return View();
        }
    }
}
