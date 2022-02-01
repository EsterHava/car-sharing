using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TemporaryTravellerDal
    {
        public static IEnumerable<temporaryTraveller> GetTemporaryTravellers()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.temporaryTraveller;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
    }
}
