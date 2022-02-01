using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class CarManagement
    {
       
        public static bool AddCar(CarDTO car)
        {
            int carId = CarDal.AddCar(Converts.CarConvert.ConvertToCar(car));
            
            return true;

        }
        public static CarDTO UpdateCar(CarDTO car)
        {
            return CarBL.UpdateCar(car);
        }
        
    }
}
