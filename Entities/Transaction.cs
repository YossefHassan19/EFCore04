using EFCore04.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore04.Entities
{
    public class Transaction
    {

        public int TransactionNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public string? Note { get; set; }

        public string AccountNumber { get; set; } = null!;
        public Account Account { get; set; } = null!;
    }
}
