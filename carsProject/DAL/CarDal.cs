using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class CarDal
    {
        public static IEnumerable<car> GetCars()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.car;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
        public static int AddCar(car car)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.car.Add(car);
                cp.SaveChanges();


                return car.id;
            }
            catch (Exception e)
            {
                return car.id;
            }
        }
        public static car UpdateCar(car car)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.Entry(car).State = System.Data.Entity.EntityState.Modified;
                cp.SaveChanges();
                return car;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
