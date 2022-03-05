using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class RegularTravelingDal
    {
        public static IEnumerable<regularTraveling> GetTravel()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.regularTraveling;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }


        public static bool AddTravel(regularTraveling travel)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.regularTraveling.Add(travel);
                cp.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        public static bool DeleteTravel(int travelId)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                regularTraveling rt = cp.regularTraveling.FirstOrDefault(t => t.id == travelId);
                if (rt != null)
                {
                    regularTraveling rtRemove = cp.regularTraveling.Remove(rt);
                }
                cp.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
                return false;
            }

        }
        public static bool UpdateTravel(regularTraveling travel)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.Entry(travel).State = System.Data.Entity.EntityState.Modified;
                cp.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //todo:log
                return false;
            }
        }
    }
}
