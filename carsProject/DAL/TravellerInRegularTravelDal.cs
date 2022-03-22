using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class TravellerInRegularTravelDal
    {
        public IEnumerable<travellerInRegularTravel> GetTravellerInRegularTravels()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.travellerInRegularTravel;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool AddTraveller(travellerInRegularTravel tr)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.travellerInRegularTravel.Add(tr);
                cp.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

        public bool deleteTraveller(travellerInRegularTravel tr)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                travellerInRegularTravel travel = cp.travellerInRegularTravel.FirstOrDefault(x => x.id == tr.id);
                cp.travellerInRegularTravel.Remove(travel);
                cp.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }

    }
}
