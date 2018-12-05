using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using My_Cookbook.Models;

namespace My_Cookbook.Controllers.Api
{
    public class RecipesController : ApiController
    {
        private ApplicationDbContext _context;

        public RecipesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/recipes
        public IEnumerable<Recipe> GetRecipes()
        {
            return _context.Recipes.ToList();
        }

        // GET /api/recipes/1
        public Recipe GetRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            
            return recipe;
        }

        // POST /api/recipes
        [HttpPost]
        public Recipe CreateRecipe(Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            return recipe;
        }

        // PUT /api/recipes/1
        [HttpPut]
        public void UpdateRecipe(int id, Recipe recipe)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipeInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            recipeInDb.Name = recipe.Name;
            recipeInDb.RecipeTypeId = recipe.RecipeTypeId;
            recipeInDb.PrepTime = recipe.PrepTime;
            recipeInDb.CookTime = recipe.CookTime;
            recipeInDb.Description = recipe.Description;
            recipeInDb.Directions = recipe.Directions;
            recipeInDb.Ingredients = recipe.Ingredients;
            recipeInDb.Username = recipe.Username;

            _context.SaveChanges();
        }

        // DELETE /api/recipes/1
        [HttpDelete]
        public void DeleteRecipe(int id)
        {
            var recipeInDb = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipeInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Recipes.Remove(recipeInDb);
            _context.SaveChanges();
        }

    }
}
