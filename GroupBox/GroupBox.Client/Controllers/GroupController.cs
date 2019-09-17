using Microsoft.AspNetCore.Mvc;
using GroupBox.Domain.Models;
using GroupBox.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            //Grab current user
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.FirstOrDefault(u => u.UserName == uName);
            
            group.Users.Add(user);

            db.Groups.Add(group);

            db.Users.Update(user);
            db.SaveChanges();

            return RedirectToAction("Group",group);
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
            //Grab current user
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.FirstOrDefault(u => u.UserName == uName);

            if(user != null)
            {
                List<Group> groupList = new List<Group>();
                foreach(Group g in db.Groups.ToList())
                {
                    if(g.Users.Any(u => u.ID == user.ID)) groupList.Add(g);
                }
                return View(groupList);
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
              Group chosenGroup = db.Groups.Include("Users").Include("Posts").FirstOrDefault(g => g.Name == group.Name);
              string user= HttpContext.Session.GetString("user");
              ViewBag.u = db.Users.FirstOrDefault(u => u.UserName == user);
              return View(chosenGroup);
          }
          else return Redirect("Allgroups");
        }

        [HttpPost]
        public IActionResult Group()
        {
            //Grab current user and group
            string gName = HttpContext.Session.GetString("group");
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.FirstOrDefault(u => u.UserName == uName);
            Group group = db.Groups.Include("Users").FirstOrDefault(g => g.Name == gName);

            if(user != null && group != null)
            {
                group.Users.Add(user);
                db.Groups.Update(group);
                db.SaveChanges();
            }

            return RedirectToAction("Group",group);
        }

        [HttpPost]
        public IActionResult Post(Post post)
        {
            //Grab current user and group
            string gName = HttpContext.Session.GetString("group");
            string uName = HttpContext.Session.GetString("user");
            User user = db.Users.FirstOrDefault(u => u.UserName == uName);
            Group group = db.Groups.Include("Users").FirstOrDefault(g => g.Name == gName);
            
            group.Posts.Add(post);
            user.Posts.Add(post);

            db.Posts.Add(post);
            db.Groups.Update(group);
            db.Users.Update(user);
            db.SaveChanges();

            return RedirectToAction("group", group);
        }
    }
}
