using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.Dtos
{
    public class RecipeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        
        public int RecipeTypeId { get; set; }

        public int PrepTime { get; set; }

        public int CookTime { get; set; } 

        public string Description { get; set; }

        public string Directions { get; set; }

        public string Ingredients { get; set; }

        public string Username { get; set; }

    }
}