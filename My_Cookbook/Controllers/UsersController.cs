using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Cookbook.Models;
using My_Cookbook.ViewModels;
using System.Data.Entity;
using System.Diagnostics;
using Microsoft.AspNet.Identity;

namespace My_Cookbook.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        
        public ActionResult Index()
        {
            var recipeList = _context.Recipes.ToList();
            List<string> UserList = new List<string>();

            foreach ( var recipe in recipeList)
            {
                UserList.Add(recipe.Username);
            }

            //no duplicates
            List<string> distinctuserList = UserList.Distinct().ToList();
           
            var viewModel = new UsersViewModel(distinctuserList);

            return View(viewModel);
        }

        // UserRecipe
        public ActionResult UserRecipe(string userName)
        {
            var targetUserRecipes = _context.Recipes.Include(c => c.RecipeType).Where(s => s.Username == userName).ToList();
            

            ViewBag.TargetUser = userName;

            if (targetUserRecipes == null)
                return HttpNotFound();

            //get logged in user's username

            var loggedInUser = User.Identity.GetUserName();

            //direct to appropriate page
            if (userName == loggedInUser)
            {
                return View("UserRecipeEdit", targetUserRecipes);
            }
            else
            {
                return View("UserRecipe", targetUserRecipes);
            }
            
        }

        public ActionResult ProfilePage()
        {


            return View("ProfilePage");
        }
    }
}