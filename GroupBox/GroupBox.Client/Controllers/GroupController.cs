using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GroupBox.Client.Models;
using GroupBox.Domain.Models;

namespace GroupBox.Client.Controllers
{
    public class GroupController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
        return View();
        } 

        [HttpPost]
        public IActionResult Create(Group group)
        {
            return View();
        }


        [HttpGet]
        public IActionResult AllGroups()
        {
            return View();
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
