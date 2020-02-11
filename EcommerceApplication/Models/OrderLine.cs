﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceApplication.Models
{
    [Table("OrderLine")]
    public class OrderLine
    {
        public int OrderLineId { get; set; }

        public int? Quantity { get; set; }

        public decimal? UnitPrice { get; set; }

        [Range(1,100, ErrorMessage = "Price must be between {0} and {1}")] // < 1 or > 100 is error 
        public decimal? Price { get; set; }

        public int? OrderId { get; set; }

        public int? ProductId { get; set; }


        public virtual Order Orders { get; set; }
        public virtual Product Products { get; set; }
    }
}