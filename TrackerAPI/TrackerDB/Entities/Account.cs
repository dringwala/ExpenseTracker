using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrackerDB.Entities
{
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        
        public string Name { get; set; }
        public string Number { get; set; }
        public string AccountType { get; set; }
        public Double AccountBalance { get; set; }
        public long UserName { get; set; }

        public ICollection<Transaction> Transactions { get; set; }
    }
}
