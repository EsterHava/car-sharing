using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL.Converts
{
    public static class TravellerInRegularTravelConvert
    {
        public static TravellerInRegularTravelDTO ConvertToTravellerInRegularTravelDTO(travellerInRegularTravel travellerInRegularTravel)
        {
            TravellerInRegularTravelDTO travellerInRegularTravelDTO = new TravellerInRegularTravelDTO();
            travellerInRegularTravelDTO.id = travellerInRegularTravel.id;
            travellerInRegularTravelDTO.regularTravelingId = travellerInRegularTravel.regularTravelingId;
            travellerInRegularTravelDTO.travelerId = travellerInRegularTravel.travelerId;
            travellerInRegularTravelDTO.collectingPoint = travellerInRegularTravel.collectingPoint;
            travellerInRegularTravelDTO.destinationPoint = travellerInRegularTravel.destinationPoint;
            return travellerInRegularTravelDTO;
        }
        public static travellerInRegularTravel ConvertToTravellerInRegularTravel(TravellerInRegularTravelDTO travellerInRegularTravelDTO)
        {
            travellerInRegularTravel travellerInRegularTravel = new travellerInRegularTravel();
            travellerInRegularTravel.id = travellerInRegularTravelDTO.id;
            travellerInRegularTravel.regularTravelingId = travellerInRegularTravelDTO.regularTravelingId;
            travellerInRegularTravel.travelerId = travellerInRegularTravelDTO.travelerId;
            travellerInRegularTravel.collectingPoint = travellerInRegularTravelDTO.collectingPoint;
            travellerInRegularTravel.destinationPoint = travellerInRegularTravelDTO.destinationPoint;
            return travellerInRegularTravel;
        }

    }
}
