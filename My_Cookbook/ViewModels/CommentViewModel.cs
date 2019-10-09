using My_Cookbook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_Cookbook.ViewModels
{
    public class CommentViewModel
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        [AllowHtml]
        public string Body { get; set; }

        public Recipe Recipe { get; set; }

        public CommentViewModel(Recipe recipe)
        {
            Recipe = recipe;
        }

        public CommentViewModel()
        {
            Id = 0;
        }

    }
}