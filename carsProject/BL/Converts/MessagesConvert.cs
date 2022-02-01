using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL.Converts
{
   public class MessagesConvert
    {

        public static MessagesDTO ConvertToMessageDTO(messages message)
        {
            MessagesDTO messageDTO = new MessagesDTO();
            messageDTO.id = message.id;
            messageDTO.userId = message.userId;
            messageDTO.message = message.message;
            messageDTO.isRead = message.isRead;
            return messageDTO;
        }
        public static messages ConvertToMessage(MessagesDTO messageDTO)
        {
            messages message = new messages();
            message.id = messageDTO.id;
            message.userId = messageDTO.userId;
            message.message = messageDTO.message;
            message.isRead = messageDTO.isRead;
            return message;
        }
    }
}
