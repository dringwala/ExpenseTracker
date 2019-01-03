using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class ExpenseTrackerDb : DbContext
    {
        public ExpenseTrackerDb() : base("name=DefaultConnection")
        {
            
        }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}