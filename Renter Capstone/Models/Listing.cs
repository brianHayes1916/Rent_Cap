using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class Listing
    {
        [Key]
        public int ListingId { get; set; }
        public int Prioirty { get; set; }
        public string Images { get; set; }
        public int Cost { get; set; }
        public string Description { get; set; }
        public int SquareFeet { get; set; }

        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
