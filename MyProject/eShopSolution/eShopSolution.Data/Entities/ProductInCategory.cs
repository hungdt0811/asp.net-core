using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public int CategoryId { get; set; }

        public Category Category { get; set; } = null!;
    }
}
