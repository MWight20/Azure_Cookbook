using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using My_Cookbook.Models;

namespace My_Cookbook.ViewModels
{
    public class RecipeFormViewModel
    {
        public IEnumerable<RecipeType> RecipeTypes { get; set; } 

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Recipe Type")]
        public int? RecipeTypeId { get; set; }

        [Required]
        [Display(Name = "Prep Time (Minutes)")]
        public int PrepTime { get; set; } //Time in minutes

        [Required]
        [Display(Name = "Cook Time (Minutes)")]
        public int CookTime { get; set; } //Time in minutes
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string Directions { get; set; }

        [Required]
        public string Ingredients { get; set; }
        
        
        [Display(Name = "Username")]
        public string Username { get; set; }

        //constructor
        public RecipeFormViewModel()
        {
            Id = 0;
        }

        public RecipeFormViewModel(Recipe recipe)
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
        }

    }
}