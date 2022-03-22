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

        public IEnumerable<MessagesDTO> GetMessages(string userId)
        {
            return msgBl.GetMessagesByUserId(int.Parse(userId));
        }

        public bool CreateMessageNewReq(JoinRequestDTO request, int driverId)
        {
            string userName = UserManagement.GetUserNameById(request.userId);
            MessagesDTO msg = new MessagesDTO();
            msg.isRead = false;
            msg.message = string.Format("{1} יש לך בקשת הצטרפות לנסיעה{0} עבור ", request.regularTravelId, userName);
            msg.userId = driverId;
            return msgBl.AddMessage(msg);
        }

        public bool CreateMessageDeleteTravel(int userId) {
            MessagesDTO msg = new MessagesDTO();
            msg.isRead = false;
            msg.userId = userId;
            msg.message = "נסיעה שהנך מצורף אליה התבטלה";
            return msgBl.AddMessage(msg);
        }

        public bool CreateMessageDeleteTravellerInTravel(int driverId) {
            MessagesDTO msg = new MessagesDTO();
            msg.isRead = false;
            msg.userId = driverId;
            msg.message = "נוסע בטל את הצטרפותו לנסיעה ";
            return msgBl.AddMessage(msg);
        }
    }
}
