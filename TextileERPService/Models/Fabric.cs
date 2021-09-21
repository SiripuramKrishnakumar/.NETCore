using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TextileERPService.Models
{
    public class Fabric
    {
        [Key]
        public int FabricId { get; set; }
        public string FabricName { get; set; }
        public int UOMId { get; set; }
        public decimal UnitValue { get; set; }
        public int COM { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        [ForeignKey("UOMId")]
        public virtual UOM UOM { get; set; }
        [ForeignKey("COM")]
        public virtual Country Country { get; set; }
        public virtual ICollection<InvoiceItem> InvoiceItems { get; set; }
    }
}
