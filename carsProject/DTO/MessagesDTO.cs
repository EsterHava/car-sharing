using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MessagesDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string message { get; set; }
        public bool isRead { get; set; }


    }
}
