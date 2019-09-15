using GroupBox.Data;
using GroupBox.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroupBox.Client.Controllers
{
    public class userController : Controller
    {
        private GroupBoxDbContext db = new GroupBoxDbContext();

        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(User newUser)
        {
            if(ModelState.IsValid)
            {
                db.Users.Add(newUser);
                db.SaveChanges();

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
        public IActionResult Login(User user)
        {
            return Redirect("/home/index");
        }
    }
}