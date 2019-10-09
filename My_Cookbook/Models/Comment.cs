using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Cookbook.Models
{
    public class Comment
    {
        [Required]
        public int Id { get; set; }

        [StringLength(50)]
        public string Author { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public int PostId { get; set; }

        //Link to existing Recipe class
        public virtual Recipe Recipe { get; set; }


    }
}