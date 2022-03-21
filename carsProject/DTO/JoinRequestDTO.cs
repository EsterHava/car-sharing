using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class JoinRequestDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public System.DateTime Date { get; set; }
        public Nullable<int> regularTravelId { get; set; }
        public Nullable<int> temporaryTravelId { get; set; }
        public int Day { get; set; }
        public string Destination { get; set; }
        public string Source { get; set; }
        public TimeSpan TimeEixt { get; set; }
        public double DestinationsRange { get; set; }
        public double SourceRange { get; set; }
        public double TimeRange { get; set; }

        public string dayList { get; set; }

    }
}
