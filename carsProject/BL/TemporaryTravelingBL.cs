using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class TemporaryTravelingBL
    {

        public static IEnumerable<TemporaryTravelingDTO> GetTravel()
        {
            var list = TemporaryTravelingDal.GetTravel();
            foreach (var item in list)
            {
                yield return Converts.TemporaryTravelingConvert.ConvertToTemporaryTravelingDTO(item);
            }

        }
        public static TemporaryTravelingDTO GetTravelById(int id)
        {
            var list = TemporaryTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.TemporaryTravelingConvert.ConvertToTemporaryTravelingDTO(item);

            }
            return null;

        }
        public static IEnumerable<TemporaryTravelingDTO> GetTravelByDriver(int driverId)
        {
            var list = TemporaryTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.driverId == driverId)
                    yield return Converts.TemporaryTravelingConvert.ConvertToTemporaryTravelingDTO(item);
            }

        }
        public static bool AddTravel(TemporaryTravelingDTO travel)
        {
            return TemporaryTravelingDal.AddTravel
                (Converts.TemporaryTravelingConvert.ConvertToTemporaryTraveling(travel));
        }
        public static bool DeleteTravel(int travelId)
        {
            return TemporaryTravelingDal.DeleteTravel(travelId);
        }
        public static bool UpdateTravel(TemporaryTravelingDTO travel)
        {
            return TemporaryTravelingDal.UpdateTravel
                (Converts.TemporaryTravelingConvert.ConvertToTemporaryTraveling(travel));
        }
    }
}
