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

            if(user != null)
            {
                return View();
            }
            else
            {
                return Redirect("/user/login");
            }
        }

        [HttpPost]
        public IActionResult MyGroups(Group group)
        {
            return View();
        }


        [HttpGet]
        public IActionResult Group(Group group)
        {
          if(group.Name != null)
          {
              HttpContext.Session.SetString("group", group.Name);
              return View(group);
          }
          else return Redirect("allgroups");
        }

        [HttpPost]
        public IActionResult Group()
        {
            string gName = HttpContext.Session.GetString("group");
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.Include("Groups").FirstOrDefault(u => u.UserName == uName);
            Group group = db.Groups.Include("Users").FirstOrDefault(g => g.Name == gName);
            if(user != null && group != null)
            {
                
                group.Users.Add(user);

                db.Users.Update(user);
                db.Groups.Update(group);
                db.SaveChanges();
            }
            return View(group);
        }
    }
}
