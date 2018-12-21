using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using My_Cookbook.Models;
using My_Cookbook.ViewModels;
using Microsoft.AspNet.Identity;

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
            return RedirectToAction("index", "Community");
        }

        // GET: Recipe/Details/username
        public ViewResult DetailsByUsername(string username)
        {
            var userRecipeList = _context.Recipes.Where(c => c.Username == username).ToList();

            return View("UserRecipe", userRecipeList);
        }

        // GET: Recipe/Details/1
        public ActionResult Details(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            //get logged in user's username
            var loggedInUser = User.Identity.GetUserName();

            //direct to appropriate page
            if (recipe.Username == loggedInUser)
            {
                return View("RecipeDetails", recipe);
            }
            else
            {
                return View("RecipeDetailsReadOnly", recipe);
            }
            

            

        }

        // New Recipe 
        public ViewResult New()
        {
            var recipeTypes = _context.RecipeTypes.ToList();
            var viewModel = new RecipeFormViewModel
            {
                RecipeTypes = recipeTypes
            };
            
            return View("RecipeForm", viewModel);
        }

        // Create recipe in DB
        public ActionResult Create(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return RedirectToAction("Index", "Recipe");
        } 

        // Save Recipe to DB
        [HttpPost]
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

            if (recipe.Id == 0) //doesn't already exist in DB
            {

                if (User.Identity.GetUserId() == null || User.Identity.GetUserName() == "" )
                {
                    recipe.Username = "Anonymous";
                }
                else //if the current user is not null
                {
                    recipe.Username = User.Identity.GetUserName();
                }

                _context.Recipes.Add(recipe);
            }
            else //Something already exists with the recipe Id.
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

            return RedirectToAction("Index", "Community");
        }

        //currently unused: add a actionlink linked to this method and a recipeEdit page
        // Edit existing recipe
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