using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Entities
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DateTime Dob {  get; set; }
        public ICollection<Cart> Carts { get; set; } = null!;
        public ICollection<Order> Orders { get; set; } = null!;
        public ICollection<Transaction> Transactions { get; set; } = null!;
    }
}
