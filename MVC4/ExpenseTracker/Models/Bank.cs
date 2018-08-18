using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Bank
    {
        public Guid BankId { get; set; }
        public string Name { get; set; }
        public string FriendlyName { get; set; }
        public Guid BankUserId { get; set; }

    }
}