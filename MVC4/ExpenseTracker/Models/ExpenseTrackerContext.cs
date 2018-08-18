using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class ExpenseTrackerContext : DbContext
    {
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BankAccount> Accounts { get; set; }
    }
}