using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string tel { get; set; }
        public string mail { get; set; }
        public Nullable<int> genderId { get; set; }
        public Nullable<int> points { get; set; }
        public Nullable<bool> isHasCar { get; set; }


    }
}
