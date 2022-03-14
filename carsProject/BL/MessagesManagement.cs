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
        MessageBL msgBl = new MessageBL();

        public IEnumerable<MessagesDTO> GetMessages(string userId) {
           return msgBl.GetMessagesByUserId(int.Parse(userId));
        }

        public bool CreateMessage(JoinRequestDTO requests)
        {
            MessagesDTO msg = new MessagesDTO();
            msg.isRead = false;
            msg.message = "יש לך בקשת הצטרפות לנסיעה " + requests.userId.ToString();
            return msgBl.AddMessage(msg);
        }
    }
}
