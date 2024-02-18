using eShopSolution.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Entities
{
    public class Transaction
    {
        public int Id { set; get; }
        public DateTime TransactionDate { set; get; }
        public int ExternalTransactionId { set; get; } 
        public decimal Amount { set; get; }
        public decimal Fee { set; get; }
        public string Result { set; get; } = null!;
        public string Message { set; get; } = null!;
        public TransactionStatus Status { set; get; }
        public string Provider { set; get; } = null!;

        public Guid UserId { get; set; }
        public User User { set; get; } = null!;

    }
}
