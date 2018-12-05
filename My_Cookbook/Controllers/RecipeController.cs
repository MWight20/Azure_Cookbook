using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_Cookbook.Models;
using My_Cookbook.ViewModels;

namespace My_Cookbook.Controllers
{
    public class RecipeController : Controller
    {
        private ApplicationDbContext _context;

        public RecipeController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Recipe
        public ActionResult Index()
        {
            return View();
        }

        // New
        public ViewResult New()
        {
            //var recipe = new Recipe()
            //{
            //    Id = 1,
            //    Name = "Nachos",
            //    RecipeTypeId = 4,
            //    PrepTime = 5,
            //    CookTime = 1,
            //    Description = "Simple and easy microwaved nachos",
            //    Directions = "Place desired amount of tortilla chips onto a microwave safe plate. Top chips with desired amount of shredded cheese of your choice. " +
            //      "Next, microwave nachos until cheese is melted. Enjoy!",
            //    Ingredients = "Corn tortilla chips, shredded cheese"
            //};

            var recipeTypes = _context.RecipeTypes.ToList();
            var viewModel = new RecipeFormViewModel
            {
                RecipeTypes = recipeTypes
            };


            return View("RecipeForm", viewModel);
        }

        public ActionResult Save(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new RecipeFormViewModel(recipe)
                {
                    RecipeTypes = _context.RecipeTypes.ToList()
                };
                return View("RecipeForm", viewModel);
            }

            if (recipe.Id == 0)
            {
                if (recipe.Username == "" || recipe.Username == null)
                {
                    recipe.Username = "Anonymous";
                }

                _context.Recipes.Add(recipe);
            }
            else
            {
                var recipeInDb = _context.Recipes.Single(c => c.Id == recipe.Id);

                recipeInDb.Name = recipe.Name;
                recipeInDb.RecipeTypeId = recipe.RecipeTypeId;
                recipeInDb.PrepTime = recipe.PrepTime;
                recipeInDb.CookTime = recipe.CookTime;
                recipeInDb.Description = recipe.Description;
                recipeInDb.Directions = recipe.Directions;
                recipeInDb.Ingredients = recipe.Ingredients;
                recipeInDb.Username = recipe.Username;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Recipe");
        }

        public ActionResult Edit(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            var viewModel = new RecipeFormViewModel(recipe)
            {
                
                RecipeTypes = _context.RecipeTypes.ToList()
            };

            return View("RecipeForm", viewModel);
        }
    }
}