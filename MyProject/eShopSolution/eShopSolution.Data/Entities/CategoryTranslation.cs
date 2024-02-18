using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class CategoryTranslation
    {
        public int Id { set; get; }
        public int CategoryId { set; get; }
        public string Name { set; get; } = null!;
        public string SeoDescription { set; get; } = null!; 
        public string SeoTitle { set; get; } = null!;
        public string LanguageId { set; get; } = null!;
        public string SeoAlias { set; get; } = null!;

        public Category Category { get; set; } = null!;

        public Language Language { get; set; } = null!;

    }
}
