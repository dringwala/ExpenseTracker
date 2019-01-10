using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class BankAccount
    {
        public Guid BankAccountId { get; set; }
        public Guid BankId { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public string RoutingNumber { get; set; }
        public string FriendlyName { get; set; }
        public string Description { get; set; }
        
    }
}