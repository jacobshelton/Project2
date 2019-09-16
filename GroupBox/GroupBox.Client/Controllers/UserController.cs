using GroupBox.Data;
using GroupBox.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Login(User userLogin)
        {
            User user = db.Users.Include("Groups").Include("Posts").FirstOrDefault(u => u.UserName == userLogin.UserName);
            HttpContext.Session.SetString("user", user.UserName);
            return RedirectToAction("AllGroups","Group");
        }

        public IActionResult Info(User user)
        {
            return View(user);
        }

    }
}