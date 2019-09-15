using GroupBox.Domain.Models;
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
        [HttpPost]
        public IActionResult CreateAccount(User newUser, Password newPassword)
        {
            if(ModelState.IsValid)
            {
                newUser.Password = newPassword;
                return RedirectToAction("Login");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User user, Password password)
        {
            return Redirect("/home/index");
        }
    }
}