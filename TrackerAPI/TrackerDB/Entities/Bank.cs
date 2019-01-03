using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerDB.Entities
{
    public class Bank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string BankUrl { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
