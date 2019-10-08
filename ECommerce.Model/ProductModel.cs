using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Model
{
    public class ProductModel
    {
        [Key]
        public int ProductCode { get; set; }

        public int Price { get; set; }

        public int Stock { get; set; }
    }
}
