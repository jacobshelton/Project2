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

                HttpContext.Session.SetString("user", newUser.UserName);
                return RedirectToAction("AllGroups","Group");
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
            foreach (User u in db.Users)
            {
                if (userLogin.UserName==u.UserName)
                {
                  HttpContext.Session.SetString("user", u.UserName);
                  return RedirectToAction("AllGroups","Group");
                }
            }
           return RedirectToAction("Index", "Home");
        }
    }
}