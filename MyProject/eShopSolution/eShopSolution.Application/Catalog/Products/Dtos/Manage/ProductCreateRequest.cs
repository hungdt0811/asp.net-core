using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Name { set; get; } = null!;
        public string Description { set; get; } = null!;
        public string Details { set; get; } = null!;
        public string SeoDescription { set; get; } = null!;
        public string SeoTitle { set; get; } = null!;
        public string SeoAlias { get; set; } = null!;
        public string LanguageId { set; get; } = null!;

    }
}
