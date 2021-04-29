using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class IntrestedParty
    {
        [Key]
        public int InterestedId { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public Listing Listing { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
