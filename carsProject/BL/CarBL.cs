using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
   public class CarBL
    {
        public static IEnumerable<CarDTO> GetCars()
        {
            var list = CarDal.GetCars();
            foreach (var item in list)
            {
                yield return Converts.CarConvert.ConvertToCarDTO(item);
            }

        }
        

        public static CarDTO GetCarById(int id)
        {
            var list = CarDal.GetCars();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.CarConvert.ConvertToCarDTO(item);
            }
            return null;
        }

        public static CarDTO UpdateCar(CarDTO car)
        {
            car u = CarDal.UpdateCar(Converts.CarConvert.ConvertToCar(car));
            if (u != null)
                return Converts.CarConvert.ConvertToCarDTO(u);
            return null;
        }

    }
}
