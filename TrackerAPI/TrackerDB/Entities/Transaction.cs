using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TrackerDB.Entities
{
    public class Transaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }
        public string StoreName { get; set; }
        public string Description { get; set; }

        public DateTimeOffset TransactionDate { get; set; }
        public Double TransactionCost { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        [Required]
        public virtual TransactionCategory Category { get; set; }
    }
}
