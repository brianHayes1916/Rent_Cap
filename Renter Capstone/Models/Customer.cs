using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class Customer
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public bool Renter { get; set; }
        public bool Leasing { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

        [ForeignKey("Listing")]
        public int ListingId { get; set; }
        public Listing Listing { get; set; }
    }
}
