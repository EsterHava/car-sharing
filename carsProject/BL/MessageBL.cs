using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class MessageBL
    {
        MessagesDal msgDal = new MessagesDal();
        public  IEnumerable<MessagesDTO> GetMessagesByUserId(int userId)
        {
            var list = msgDal.GetMessages();
            foreach (var item in list)
            {
                if (item.userId == userId)
                    yield return Converts.MessagesConvert.ConvertToMessageDTO(item);
            }
        }

        public bool AddMessage(MessagesDTO msg) {
            return msgDal.AddMessage(Converts.MessagesConvert.ConvertToMessage(msg));
        }

    }
}
