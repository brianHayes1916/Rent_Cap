using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class IndexViewModel
    {
        public List<Listing> listings { get; set; }
        public List<RealEstateListing> estateListings { get; set; }
    }
}
