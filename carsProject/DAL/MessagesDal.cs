using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MessagesDal
    {
        public IEnumerable<messages> GetMessages()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.messages;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool AddMessage(messages msg)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.messages.Add(msg);
                cp.SaveChanges();
            
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
