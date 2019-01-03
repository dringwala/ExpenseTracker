using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerAPI.Models
{
    public class BankModel
    {
        public ICollection<LinkModel> Links;
        //public long Id { get; set; }
        public string Name { get; set; }
        public string BankUrl { get; set; }
        public bool IsActive { get; set; }
        public IEnumerable<AccountModel> Accounts;
    }
}
