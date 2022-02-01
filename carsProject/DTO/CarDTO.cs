using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CarDTO
    {
        public int id { get; set; }
        public Nullable<int> userId { get; set; }
        public Nullable<int> numOfSeats { get; set; }
        public int carNumber { get; set; }
        public Nullable<int> numOfAvailableSeats { get; set; }

       // public virtual user user { get; set; }

    }
}
