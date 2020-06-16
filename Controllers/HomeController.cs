using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Products.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Products.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        public HomeController(MyContext context)
        {
            dbContext = context;
        }
//***************************************************************  GET REQUEST ******************************************************//
        // view product page //
        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.AllProducts = dbContext.Products;
            return View();
        }

        // view category page //
        [HttpGet("Categories")]
        public IActionResult Categories()
        {
            ViewBag.AllCategories = dbContext.Categories;
            return View();
        }

        [HttpGet("productview/{ProductId}")]
        public ViewResult ProductView(int ProductId)
        {
            ViewBag.Product = dbContext.Products.Include(pro =>pro.ProCats).ThenInclude(ass => ass.Category).FirstOrDefault(product => product.ProductId == ProductId);
            ViewBag.Category = dbContext.Categories;
            return View("ProductView");
        }

        [HttpGet("categoryview/{CategoryId}")]
        public ViewResult CategoryView(int CategoryId)
        {
            ViewBag.Category = dbContext.Categories.Include(cat =>cat.ProCats).ThenInclude(ass => ass.Product).FirstOrDefault(cat => cat.CategoryId == CategoryId);
            ViewBag.Product = dbContext.Products;
            return View("CategoryView");
        }


//***************************************************************  POST REQUEST ******************************************************//
        [HttpPost("newproduct")]
        public IActionResult NewProduct(Product FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return Index();
        }

        [HttpPost("newcategory")]
        public IActionResult NewCategory(Category FromForm)
        {
            if(ModelState.IsValid)
            {
                dbContext.Add(FromForm);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            return Categories();
        }

        [HttpPost("addtocategory/{ProductId}")]
        public IActionResult AddToCategory(Association FromForm, int ProductId)
        {
            FromForm.ProductId = ProductId;
            if(ModelState.IsValid)
            {
                dbContext.Add(FromForm);
                dbContext.SaveChanges();
                return ProductView(ProductId);
            }
            else{
                return ProductView(ProductId);
            }
        }
    }
}
