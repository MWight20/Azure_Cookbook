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
        

        public int Id { get; set; }

        [Required(ErrorMessage ="The Name field is required.")]
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

        //[Range(0, 5)]
        //public int? Rating { get; set; }

        //[display(name = "date created")]
        //[displayformat(dataformatstring = "{0: mmm d yyyy}", applyformatineditmode = true)]
        //public datetime? datecreated { get; set; }

        //public virtual ApplicationUser User { get; set; }

        //public int UserID { get; set; }





    }
}