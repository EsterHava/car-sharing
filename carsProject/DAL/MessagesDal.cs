using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class MessagesDal
    {
        public static IEnumerable<messages> GetMessages() {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.messages;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
    }
}
