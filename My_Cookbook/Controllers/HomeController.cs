using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace My_Cookbook.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Username = User.Identity.GetUserName();
            if (Username == "")
            {
                Username = "No logged in user.";
            }
                ViewBag.UserName = Username;
            
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}