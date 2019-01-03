using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ExpenseTracker.Models
{
    public class Bank
    {
        public Bank()
        {
            BankId = Guid.NewGuid();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BankId { get; set; }
        [StringLength(1024)]
        [Required]
        public string Name { get; set; }
        [StringLength(1024)]
        [DisplayName("Nick Name")]
        public string FriendlyName { get; set; }
        public Guid BankUserId { get; set; }
        public string BankStatus { get; set; }
        public virtual ICollection<BankAccount> Accounts { get; set; }


    }
}