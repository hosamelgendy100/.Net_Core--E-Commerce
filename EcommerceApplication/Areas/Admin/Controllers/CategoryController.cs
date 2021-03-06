﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;
using Microsoft.AspNetCore.Identity;
using EcommerceApplication.Models;

namespace EcommerceApplication.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryRepository;
        
        public CategoryController(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _categoryRepository.GetAll();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            _categoryRepository.Insert(category);
            _categoryRepository.Save();
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Models.Category category = _categoryRepository.GetById(id);
            if (category == null)
            {
                throw new Exception("Category Not Found");
            }
            return View(category);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Update(Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Home");
            }

            _categoryRepository.Update(category);
            _categoryRepository.Save();
            return RedirectToAction("Index", "Category", "Admin");
        }

    }
}
