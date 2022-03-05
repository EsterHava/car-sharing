using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Web.Configuration;
using System.Web;
using System.Net;
using System.Xml.Linq;

namespace BL
{
    public class RegularTravelingBL
    {
        public static IEnumerable<RegularTravelingDTO> GetTravel()
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }

        }
        public static IEnumerable<RegularTravelingDTO> GetTravelByDriver(int driverId)
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.driverId == driverId)
                    yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }

        }
        public static RegularTravelingDTO GetTravelById(int id)
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);

            }
            return null;

        }
        public static bool AddTravel(RegularTravelingDTO travel)
        {
            Location locationSource = new Location();
            locationSource = GoogleMapService.getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = GoogleMapService.getPosition(travel.destination);
            travel.latDestination = locationDestination.lat;
            travel.longDestination = locationDestination.lng;

            return RegularTravelingDal.AddTravel
            (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }
        public static bool DeleteTravel(int travelId)
        {
            return RegularTravelingDal.DeleteTravel(travelId);
        }
        public static bool UpdateTravel(RegularTravelingDTO travel)
        {
            Location locationSource = GoogleMapService.getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = GoogleMapService.getPosition(travel.destination);
            travel.latSourcr = locationDestination.lat;
            travel.longSource = locationDestination.lng;

            return RegularTravelingDal.UpdateTravel
                (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }
    }
}
