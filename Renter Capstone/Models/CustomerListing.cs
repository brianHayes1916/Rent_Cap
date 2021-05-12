using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class CustomerListing
    {
        [Key]
        public int ListingId { get; set; }
        public int Prioirty { get; set; }
        //public int Cost { get; set; }
        public string Description { get; set; }
        //public int SquareFeet { get; set; }
        public int NumberOfRoomMates { get; set; }
        public int YearPref { get; set; }

        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }


    }
}
