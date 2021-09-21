using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace TextileERPService.Models
{
    public class Bill
    {
        public int BillId { get; set; }
        [MinLength(10)]
        public string BillNumber { get; set; }
        public int InvoiceId { get; set; }
        public decimal InvoiceAmount { get; set; }
        [Range(0,100)]
        public int DiscPerc { get; set; }
        public decimal DiscAmount { get; set; }
        public decimal ActualAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
    }
}
