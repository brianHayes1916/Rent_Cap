using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Latitute { get; set; }
        public double Longitude { get; set; }
    }
}
