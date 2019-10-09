using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.ViewModels
{
    public class RecipeViewModel
    {
        public IEnumerable<RecipeType> RecipeTypes { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }


        public RecipeType RecipeType { get; set; }

        [Display(Name = "Recipe Type")]
        public int RecipeTypeId { get; set; }

        [Required]
        public int PrepTime { get; set; } //Time in minutes

        [Required]
        public int CookTime { get; set; } //Time in minutes

        [Required]
        public string Description { get; set; }

        [Required]
        public string Directions { get; set; }

        [Required]
        public string Ingredients { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public CommentViewModel CommentVM { get; set; }

        public RecipeViewModel(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            RecipeTypeId = recipe.RecipeTypeId;
            PrepTime = recipe.PrepTime;
            CookTime = recipe.CookTime;
            Description = recipe.Description;
            Directions = recipe.Directions;
            Ingredients = recipe.Ingredients;
            Username = recipe.Username;
            CommentVM = new CommentViewModel(recipe);
        }
    }
}