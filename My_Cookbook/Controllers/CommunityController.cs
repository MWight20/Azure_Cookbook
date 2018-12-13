using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Cookbook.Models;
using My_Cookbook.ViewModels;

namespace My_Cookbook.Controllers
{
    public class CommunityController : Controller
    {
        private ApplicationDbContext _context;

        public CommunityController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Community
        public ActionResult Index()
        {
            var recipesListinDB = _context.Recipes.ToList();

            //var viewModel = new CommunityViewModel();

            //foreach (var value in recipeslistindb)
            //{
            //    viewmodel.userrecipes.add(value);
            //}

            return View(recipesListinDB);
        }
    }
}