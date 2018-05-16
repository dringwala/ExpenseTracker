using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrackerAPI.Models
{
    public class Bank
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string RoutingNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
