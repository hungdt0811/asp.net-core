using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Contact
    {
        public int Id { set; get; }
        public string Name { set; get; } = null!;
        public string Email { set; get; } = null!;
        public string PhoneNumber { set; get; } = null!;
        public string Message { set; get; } = null!;
        public Status Status { set; get; }

    }
}
