using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RegularTravelingDTO
    {
        public int id { get; set; }
        public Nullable<int> driverId { get; set; }
        public string source { get; set; }
        public string destination { get; set; }
        public Nullable<double> longDestination { get; set; }
        public Nullable<double> latDestination { get; set; }
        public Nullable<double> longSource { get; set; }
        public Nullable<double> latSourcr { get; set; }
        public Nullable<System.TimeSpan> exitTime { get; set; }
        public Nullable<System.TimeSpan> arriveTime { get; set; }
        public Nullable<int> day { get; set; }

    }
}
