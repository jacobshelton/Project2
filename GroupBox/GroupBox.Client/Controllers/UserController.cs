using Microsoft.AspNetCore.Mvc;

namespace GroupBox.Client.Controllers
{
    public class userController : Controller
    {
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}