using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class ProductTranslation
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; } = null!;
        public string Description { set; get; } = null!;
        public string Details { set; get; } = null!;
        public string SeoDescription { set; get; } = null!;
        public string SeoTitle { set; get; } = null!;
        public string SeoAlias { get; set; } = null!;
        public string LanguageId { set; get; } = null!;

        public Product Product { get; set; } = null!;

        public Language Language { get; set; } = null!; 

    }
}
