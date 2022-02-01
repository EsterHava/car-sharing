using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;


namespace BL.Converts
{
    public static class CarConvert
    {
        public static CarDTO ConvertToCarDTO(car car)
        {
            CarDTO carDTO = new CarDTO();
            carDTO.id = car.id;
            carDTO.userId = car.userId;
            carDTO.numOfSeats = car.numOfSeats;
            carDTO.carNumber = car.carNumber;
            carDTO.numOfAvailableSeats = car.numOfAvailableSeats;
            return carDTO;
        }
        public static car ConvertToCar(CarDTO carDTO)
        {
            car car = new car();
            car.id = carDTO.id;
            car.userId = carDTO.userId;
            car.numOfSeats = carDTO.numOfSeats;
            car.carNumber = carDTO.carNumber;
            car.numOfAvailableSeats = carDTO.numOfAvailableSeats;
            return car;
        }
    }
}
