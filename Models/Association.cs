using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace Products.Models
{
    public class Association
    {
        [Key]
        public int AssociationId{get; set;}

        [Required]
        public int ProductId{get; set;}

        public Product Product{get; set;}

        [Required]
        public int CategoryId{get; set;}

        public Category Category{get; set;}
    }
}