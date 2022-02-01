using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TravellerInRegularTravelDTO
    {
        public int id { get; set; }
        public Nullable<int> regularTravelingId { get; set; }
        public Nullable<int> travelerId { get; set; }
        public string collectingPoint { get; set; }
        public string destinationPoint { get; set; }
    }
}
