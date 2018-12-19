using AutoMapper;
using My_Cookbook.Dtos;
using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace My_Cookbook.Controllers.Api
{
    public class UsersController : ApiController
    {
        private ApplicationDbContext _context;

        public UsersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/users
        public IEnumerable<string> GetUsernameList()
        {
            //var RecipeList = _context.Recipes.ToList().Select(Mapper.Map<Recipe, RecipeDto>);

            var recipeList = _context.Recipes.ToList();
            List<string> UserList = new List<string>();

            foreach (var recipe in recipeList)
            {
                UserList.Add(recipe.Username);
            }

            //no duplicates
            List<string> distinctuserList = UserList.Distinct().ToList();

            return distinctuserList;

        }
    }
}
