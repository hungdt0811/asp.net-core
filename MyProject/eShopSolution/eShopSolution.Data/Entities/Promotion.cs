using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Promotion
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; } = null!;
        public decimal? DiscountAmount { set; get; }
        public string ProductIds { set; get; } = null!;
        public string ProductCategoryIds { set; get; } = null!;
        public Status Status { set; get; }
        public string Name { set; get; } = null!;

    }
}
