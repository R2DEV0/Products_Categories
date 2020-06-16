using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Products.Models
{
    public class Category
    {
        [Key]
        public int CategoryId{get; set;}


        [Required(ErrorMessage="Category name is required")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters long")]
        public string Name{get; set;}

        public List<Association> ProCats{get; set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}