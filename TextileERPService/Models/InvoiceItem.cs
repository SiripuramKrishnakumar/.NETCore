using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace TextileERPService.Models
{
    public class InvoiceItem
    {
        [Key]
        public int ItemId { get; set; }
        public int InvoiceId { get; set; }
        public int FabricId { get; set; }
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("InvoiceId")]
        public virtual Invoice Invoice { get; set; }
        [ForeignKey("FabricId")]
        public virtual Fabric Fabric { get; set; }

    }
}
