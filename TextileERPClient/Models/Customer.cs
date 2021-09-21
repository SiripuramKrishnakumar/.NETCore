using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TextileERPClient.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Char Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}
