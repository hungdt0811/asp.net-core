using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
   public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; } = null!;
        public string ShipAddress { set; get; } = null!;
        public string ShipEmail { set; get; } = null!;
        public string ShipPhoneNumber { set; get; } = null!;
        public OrderStatus Status { set; get; }

        public List<OrderDetail> OrderDetails { get; set; } = null!;
        public User User { set; get; } = null!;
    }
}
