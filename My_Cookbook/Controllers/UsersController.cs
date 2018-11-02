using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Cookbook.Models;

namespace My_Cookbook.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ViewResult Index()
        {
            //var user = new User() { Name = "Mike" };

            //return View(user);
            return View("Index");
        }
    }
}