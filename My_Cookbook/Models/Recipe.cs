using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(0, 5)]
        public int? Rating { get; set; }

        public RecipeType Type { get; set; }

        [Display(Name = "Date Created")]
        [DisplayFormat(DataFormatString = "{0: MMM d yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        
    }
}