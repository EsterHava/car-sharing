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
        public static IEnumerable<MessagesDTO> GetMessagesByUserId(int userId)
        {
            var list = MessagesDal.GetMessages();
            foreach (var item in list)
            {
                if (item.userId == userId)
                    yield return Converts.MessagesConvert.ConvertToMessageDTO(item);
            }
        }

    }
}
