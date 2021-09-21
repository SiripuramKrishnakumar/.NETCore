using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextileERPService.Models
{
    public class Invoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public int CustomerId { get; set; }
        public string InvoiceNumber { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public string Narration { get; set; }
        public bool IsPaid { get; set; }
        public bool IsPartialPaid { get; set; }
        public bool IsLocked { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
        public virtual Bill Bill { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
        
    }
}
