using EcommerceApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.Areas.Admin.ViewModels
{
    public class CreateProductViewModel
    {
        public Product Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
