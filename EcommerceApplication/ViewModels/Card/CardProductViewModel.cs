using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.ViewModels.Card
{
    public class CardProductViewModel
    {
        public int ProductId { get; set; }

        public String ProductName { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal ProductTotal { get; set; }

    }
}
