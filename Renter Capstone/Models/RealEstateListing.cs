using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class RealEstateListing
    {

        public class Rootobject
        {
            public int price { get; set; }
            public float priceRangeLow { get; set; }
            public float priceRangeHigh { get; set; }
            public float longitude { get; set; }
            public float latitude { get; set; }
            public Listing[] listings { get; set; }
        }

        public class Listing
        {
            public string id { get; set; }
            [JsonProperty(PropertyName = "formattedAddress")]
            public string formattedAddress { get; set; }
            public float longitude { get; set; }
            public float latitude { get; set; }
            public string city { get; set; }
            public string state { get; set; }
            public string zipcode { get; set; }
            public int price { get; set; }
            public DateTime publishedDate { get; set; }
            public float distance { get; set; }
            public float daysOld { get; set; }
            public float correlation { get; set; }
            public string address { get; set; }
            public string county { get; set; }
            public int bedrooms { get; set; }
            public float bathrooms { get; set; }
            public string propertyType { get; set; }
            public int squareFootage { get; set; }
        }

    }
}
