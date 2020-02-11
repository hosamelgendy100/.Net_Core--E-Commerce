using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;

namespace EcommerceApplication.Controllers
{
    [Route("[controller]/[action]")]
    public class CategoriesController : Controller
    {
        private readonly ICategory _categoryRepository;

        public CategoriesController (ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll().ToList();
            return View(category);
        }

        public IActionResult CategoryDetail()
        {
            return View();
        }
    }
}