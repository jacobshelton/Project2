using Microsoft.AspNetCore.Mvc;
using GroupBox.Domain.Models;
using GroupBox.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace GroupBox.Client.Controllers
{
    public class GroupController : Controller
    {
        private GroupBoxDbContext db = new GroupBoxDbContext();

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public IActionResult Create(Group group)
        {
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.FirstOrDefault(u => u.UserName == uName);
            user.Groups.Add(group);
            group.Users.Add(user);

            db.Groups.Add(group);

            db.Users.Update(user);
            db.SaveChanges();

            return View();
        }


        [HttpGet]
        public IActionResult AllGroups()
        {
            ViewBag.u = HttpContext.Session.GetString("user");
            return View(db.Groups.ToList());
        }

        [HttpPost]
        public IActionResult AllGroups(Group group)
        {
          return View();
        }

        public IActionResult GroupFind(int id)
        {
           foreach(Group group in db.Groups)
          {
            if (id == group.ID)
            {
              return RedirectToAction("Group", group);
            }
          }
          return RedirectToAction("AllGroups","Group");
        }


        [HttpGet]
        public IActionResult MyGroups()
        {
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.Include("Groups").FirstOrDefault(u => u.UserName == uName);

            return View(user.Groups);
        }

        [HttpPost]
        public IActionResult MyGroups(Group group)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Group(Group group)
        {
          ViewBag.gname= group.Name;
          return View();
        }

        [HttpPost]
        public IActionResult Group()
        {
            
            return View();
        }
    }
}
