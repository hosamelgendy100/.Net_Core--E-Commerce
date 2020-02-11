using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EcommerceApplication.Services.Infrastructure;

namespace EcommerceApplication.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class CategoryNgController : Controller
    {
        private readonly ICategory _categoryRepository;

        public CategoryNgController(ICategory categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        #region Get

        public Models.Category Get(int id)
        {
            var category = _categoryRepository.GetById(id);
            return category;
        }

        #endregion

        #region GetAll

        public List<Models.Category> GetAll ()
        {
            var categories = _categoryRepository.GetAll().ToList();
            return categories;
        }

        #endregion

        #region CreateNg

        [HttpPost]
        public IActionResult Create([FromBody] Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _categoryRepository.Insert(category);
            _categoryRepository.Save();
            return Ok(category);
        }

        #endregion

        #region UpdateNg

        [HttpPut]
        public IActionResult Update([FromBody] Models.Category category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _categoryRepository.Update(category);
            _categoryRepository.Save();
            return NoContent();
        }

        #endregion

        #region DeleteNg

        public IActionResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = _categoryRepository.GetById(id);
            if (category==null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(id);
            _categoryRepository.Save();
            return Ok(category);
        }

        #endregion

    }
}