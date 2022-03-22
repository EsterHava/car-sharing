using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class JoinRequestDal
    {

        public IEnumerable<joinRequests> GetRequests()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.joinRequests;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public bool AddRequest(joinRequests Request)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.joinRequests.Add(Request);
                cp.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public joinRequests AddAndReturnRequest(joinRequests Request)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                joinRequests r = cp.joinRequests.Add(Request);
                cp.SaveChanges();
                return r;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public bool DeleteRequest(int requsetId)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                joinRequests r = cp.joinRequests.FirstOrDefault(t => t.id == requsetId);
                cp.joinRequests.Remove(r);
                cp.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
