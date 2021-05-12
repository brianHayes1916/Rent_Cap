using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class IndexViewModel
    {
        public CustomerListing Listing { get; set; }
        public RealEstateListing.Rootobject RealEstateListingRootObject { get; set; }
        public RealEstateListing.Listing RealEstateListingListing { get; set; }

    }
}
