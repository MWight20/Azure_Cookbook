using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.Models
{
    public class Recipe
    {

        /* Model attributes:
         * 
         * Name
         * Rating
         * Type
         * PrepTime
         * CookTime
         * ReadyTime
         * DateCreated
         * User
        */
        
            //Directions and IngredientList need their own tables

        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(0, 5)]
        public int? Rating { get; set; }

        public RecipeType RecipeType { get; set; }

        [Required]
        [Display(Name = "Recipe Type")]
        public int RecipeTypeId { get; set; }

        public int PrepTime { get; set; } //Time in minutes

        public int CookTime { get; set; } //TIme in minutes

        public int ReadyTime
        {
            get
            {
                return CookTime + PrepTime;
            }
            set
            {
                ReadyTime = value;
            }
        }

        public List<string> Directions { get; set; }
        
        public List<string> IngredientList { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0: MMM d yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        
    }
}