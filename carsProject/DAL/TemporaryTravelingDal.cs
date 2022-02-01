using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;


namespace DAL
{
    public class TemporaryTravelingDal
    {
        public static IEnumerable<temporaryTraveling> GetTravel()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.temporaryTraveling;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
        public static bool AddTravel(temporaryTraveling travel)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.temporaryTraveling.Add(travel);
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
                temporaryTraveling tt = cp.temporaryTraveling.FirstOrDefault(t => t.id == travelId);
                cp.temporaryTraveling.Remove(tt);
                cp.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                //todo:log
                return false;
            }
        }
        public static bool UpdateTravel(temporaryTraveling travel)
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
