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
        public virtual StoreDetails StoreDetail { get; set; }
        public string Description { get; set; }
        public DateTimeOffset TransactionDateTime { get; set; }
        [Required]
        public Double TransactionAmount { get; set; }
        public byte[] Receipt { get; set; }
        public string StoreTransactionID { get; set; }
        public string UserName { get; set; }
        [Required]
        public virtual Account Account { get; set; }
        [Required]
        public virtual TransactionCategory TransactionCategory { get; set; }
        public string Tags { get; set; }
    }
}
