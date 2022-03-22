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
        TravellerInRegularTravelDal travellerInDal = new TravellerInRegularTravelDal();
        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerInRegularTravels()
        {
            var list = travellerInDal.GetTravellerInRegularTravels();
            foreach (var item in list)
            {
                yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }
        }

        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerInRegularTravelsByTravelId(int idTravel)
        {
            var list = travellerInDal.GetTravellerInRegularTravels().Where(x => x.regularTravelingId == idTravel);
            foreach (var item in list)
            {
                yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }
        }

        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerTravelingsByTraveller(int travellerId)
        {
            var list = travellerInDal.GetTravellerInRegularTravels();
            foreach (var item in list)
            {
                if (item.travelerId == travellerId)
                    yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }
        }

        public bool AddTraveller(JoinRequestDTO req)
        {
            TravellerInRegularTravelDTO traveller = new TravellerInRegularTravelDTO();
            traveller.regularTravelingId = req.regularTravelId;
            traveller.travelerId = req.userId;
            traveller.destinationPoint = req.Destination;
            traveller.collectingPoint = req.Source;
            return travellerInDal.AddTraveller(Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravel(traveller));
        }
    
        public bool deleteTraveller(TravellerInRegularTravelDTO tr)
        {
            return travellerInDal.deleteTraveller(Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravel(tr));
        }
    }
}
