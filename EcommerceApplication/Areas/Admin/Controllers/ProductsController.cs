using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;
using Microsoft.AspNetCore.Identity;
using EcommerceApplication.Models;
using EcommerceApplication.Areas.Admin.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EcommerceApplication.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly IProduct _productRepository;
        private readonly ICategory _categoryRepository;
        private readonly UserManager<Customer> _userManager;
        private IHostingEnvironment _environment;

        public ProductsController(IProduct productRepository, ICategory categoryRepository, UserManager<Customer> userManager,
            IHostingEnvironment environment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var product = _productRepository.GetAll();

            return View(product);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var createProduct = new CreateProductViewModel
            {
                Products = new Product(),
                Categories = _categoryRepository.GetAll().ToList()
            };

            return View(createProduct);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(CreateProductViewModel productVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            // Create Image

            if (productVM.Products.ProductImage.Length > 0)
            {
                var uploads = Path.Combine(_environment.WebRootPath, "uploads");

                using (var fileStream = new FileStream(Path.Combine
                    (uploads, productVM.Products.ProductImage.FileName), FileMode.Create))
                {
                    productVM.Products.ProductImage.CopyTo(fileStream);
                }
                productVM.Products.ProductImagePath = productVM.Products.ProductImage.FileName.ToString();
            }

            _productRepository.Insert(productVM.Products);

            try
            {
                _productRepository.Save();
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
