using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class TravellerInRegularTravelBL
    {
        public static IEnumerable<TravellerInRegularTravelDTO> GetTravellerInRegularTravels()
        {
            var list = TravellerInRegularTravelDal.GetTravellerInRegularTravels();
            foreach (var item in list)
            {
                yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }

        }

        public static IEnumerable<TravellerInRegularTravelDTO> GetTravellerInRegularTravelsByTravelId(int idTravel)
        {
            var list = TravellerInRegularTravelDal.GetTravellerInRegularTravels().Where(x=>x.regularTravelingId== idTravel);
            foreach (var item in list)
            {
                yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }

        }
        public static IEnumerable<TravellerInRegularTravelDTO> GetTravellerTravelingsByTraveller(int travellerId)
        {
            var list = TravellerInRegularTravelDal.GetTravellerInRegularTravels();
            foreach (var item in list)
            {
                if (item.travelerId == travellerId)
                    yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }
            
        }
    }
}
