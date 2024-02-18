using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Language
    {
        public string Id { get; set; } = null!;

        public string Name { get; set; } = null!;

        public bool IsDefault { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; } = null!;

        public List<CategoryTranslation> CategoryTranslations { get; set; } = null!;
    }
}
