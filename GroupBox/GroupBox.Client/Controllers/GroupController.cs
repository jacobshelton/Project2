using Microsoft.AspNetCore.Mvc;
using GroupBox.Domain.Models;
using GroupBox.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;

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
            db.Groups.Add(group);
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
          return RedirectToAction("Login","User");
        }


        [HttpGet]
        public IActionResult MyGroups()
        {
            return View();
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
