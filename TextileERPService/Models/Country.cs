using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextileERPService.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<Fabric> Fabric { get; set; }
    }
}
