using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BL
{
    public class MessagesManagement
    {
        public static IEnumerable<MessagesDTO> GetMessages(string userId) {
           return MessageBL.GetMessagesByUserId(int.Parse(userId));
        }

    }
}
