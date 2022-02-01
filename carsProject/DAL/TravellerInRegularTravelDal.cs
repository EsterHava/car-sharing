using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TravellerInRegularTravelDal
    {
        public static IEnumerable<travellerInRegularTravel> GetTravellerInRegularTravels()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.travellerInRegularTravel;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
    }
}
