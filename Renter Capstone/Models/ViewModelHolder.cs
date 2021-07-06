using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Renter_Capstone.Models
{
    public class ViewModelHolder
    {
        public List<IndexViewModel> IndexViewModels { get; set; }
        public List<int> Prices { get; set; }
        public List<int> Beds { get; set; }
        public List<float> Baths { get; set; }
        public List<int> RoomMates { get; set; }
        public List<SelectListItem> PricesSelect { get; set; }
        public List<SelectListItem> BedsSelect { get; set; }
        public List<SelectListItem> BathsSelect { get; set; }
        public List<SelectListItem> RoomMatesSelect { get; set; }
    }
}
