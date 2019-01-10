using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrackerDB.Entities
{
    public class TransactionCategory
    {
        [Key]
        public string Category { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// True is Credit, False is Debit
        /// </summary>
        public bool Credit { get; set; }
    }
}
