using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;
using EcommerceApplication.Services.Repository;

namespace EcommerceApplication.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProduct _productRepository;
        private readonly ICategory _categoryRepository;

        public ProductController (IProduct productRepository, ICategory categoryRepository) 
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var products = _productRepository.GetAll().ToList();
            return View(products);
        }

        public IActionResult ProductDetail( int? id)
        {
            if (id==null)
            {
                return RedirectToAction("Index");
                // return RedirectToAction("Home", "Error");
            }
            return View(_productRepository.GetById(Convert.ToInt32(id)));
        }
    }
}