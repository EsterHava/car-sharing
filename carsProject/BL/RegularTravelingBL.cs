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
        RegularTravelingDal travelingDal = new RegularTravelingDal();
        public IEnumerable<RegularTravelingDTO> GetTravel()
        {
            var list = travelingDal.GetTravel();
            foreach (var item in list)
            {
                yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }
        }

        public IEnumerable<RegularTravelingDTO> GetTravelByDriver(int driverId)
        {
            var list = travelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.driverId == driverId)
                    yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }
        }

        public RegularTravelingDTO GetTravelById(int id)
        {
            var list = travelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);

            }
            return null;
        }

        public bool AddTravel(RegularTravelingDTO travel)
        {
            Location locationSource = new Location();
            locationSource = GoogleMapService.getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = GoogleMapService.getPosition(travel.destination);
            travel.latDestination = locationDestination.lat;
            travel.longDestination = locationDestination.lng;

            return travelingDal.AddTravel
            (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }

        public bool DeleteTravel(int travelId)
        {
            return travelingDal.DeleteTravel(travelId);
        }

        public bool UpdateTravel(RegularTravelingDTO travel)
        {
            Location locationSource = GoogleMapService.getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = GoogleMapService.getPosition(travel.destination);
            travel.latSourcr = locationDestination.lat;
            travel.longSource = locationDestination.lng;

            return travelingDal.UpdateTravel
                (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }
    }
}
