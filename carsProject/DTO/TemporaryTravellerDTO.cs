using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TemporaryTravellerDTO
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<int> travelId { get; set; }
        public Nullable<int> travellerId { get; set; }
        public string collectionPoint { get; set; }
        public string destinationPoint { get; set; }
        public Nullable<bool> isRegular { get; set; }
    }
}
