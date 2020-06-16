using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;


namespace Products.Models
{
    public class Product
    {
        [Key]
        public int ProductId{get; set;}

        [Required(ErrorMessage="Product name is required")]
        [MinLength(2, ErrorMessage="Name must be at least 2 characters long")]
        public string Name{get; set;}

        [Required(ErrorMessage="A product description is required")]
        [MinLength(5, ErrorMessage="Desription must be at least 5 characters long")]
        public string Description{get; set;}

        [Required(ErrorMessage="Product price is required")]
        [Range(0,10000000000, ErrorMessage="Price must be a positive number")]
        public decimal Price{get; set;}

        public List<Association> ProCats{get; set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}
