using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using My_Cookbook.Dtos;
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
        public IEnumerable<RecipeDto> GetRecipes()
        {
            return _context.Recipes.ToList().Select(Mapper.Map<Recipe,RecipeDto>);
        }

        // GET /api/recipes/1
        public IHttpActionResult GetRecipe(int id)
        {
            var recipe = _context.Recipes.SingleOrDefault(c => c.Id == id);

            if (recipe == null)
            {
                return NotFound();
            }
            
            return Ok(Mapper.Map<Recipe, RecipeDto> (recipe));
        }

        // POST /api/recipes
        [HttpPost]
        public IHttpActionResult CreateRecipe(RecipeDto recipeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(); ;
            }

            if (recipeDto.Username == "" || recipeDto.Username == null)
            {
                recipeDto.Username = "Anonymous";
            }

            var recipe = Mapper.Map<RecipeDto, Recipe>(recipeDto);
            _context.Recipes.Add(recipe);
            _context.SaveChanges();

            recipeDto.Id = recipe.Id;

            return Created(new Uri(Request.RequestUri + "/" + recipe.Id), recipeDto );
        }

        // PUT /api/recipes/1
        [HttpPut]
        public void UpdateRecipe(int id, RecipeDto recipeDto)
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

            //This line can be simplified to removing the <RecipeDto, Recipe>
            Mapper.Map<RecipeDto, Recipe>(recipeDto, recipeInDb);

            // The line above means we dont need to track changes via assignment, we're doing it via mapping instead.

            //recipeInDb.Name = recipeDto.Name;
            //recipeInDb.RecipeTypeId = recipeDto.RecipeTypeId;
            //recipeInDb.PrepTime = recipeDto.PrepTime;
            //recipeInDb.CookTime = recipeDto.CookTime;
            //recipeInDb.Description = recipeDto.Description;
            //recipeInDb.Directions = recipeDto.Directions;
            //recipeInDb.Ingredients = recipeDto.Ingredients;
            //recipeInDb.Username = recipeDto.Username;

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
