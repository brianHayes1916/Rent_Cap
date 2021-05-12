using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class InterestedParty
    {
        [Key]
        public int InterestedId { get; set; }

        [ForeignKey("CustomerListing")]
        public int ListingId { get; set; }
        public CustomerListing Listing { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
