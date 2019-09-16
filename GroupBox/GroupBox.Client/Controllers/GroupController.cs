using Microsoft.AspNetCore.Mvc;
using GroupBox.Domain.Models;
using GroupBox.Data;
using System.Linq;

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
            return View(db.Groups.ToList());
        }

        [HttpPost]
        public IActionResult AllGroups(Group group)
        {
            return View();
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
        public IActionResult Group()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Group(Group group)
        {
            return View();
        }
    }
}
