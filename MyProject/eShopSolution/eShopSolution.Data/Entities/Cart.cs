using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public DateTime CreateDated { get; set; }

        public Guid UserId { set; get; }
        public User User { set; get; } = null!;
        public Product Product { set; get; } = null!;
    }
}
