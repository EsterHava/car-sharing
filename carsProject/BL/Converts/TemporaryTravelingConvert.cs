using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL.Converts
{
    public static class TemporaryTravelingConvert
    {
        public static TemporaryTravelingDTO ConvertToTemporaryTravelingDTO(temporaryTraveling temporaryTraveling)
        {
            TemporaryTravelingDTO temporaryTravelingDTO = new TemporaryTravelingDTO();
            temporaryTravelingDTO.id = temporaryTraveling.id;
            temporaryTravelingDTO.driverId = temporaryTraveling.driverId;
            temporaryTravelingDTO.source = temporaryTraveling.source;
            temporaryTravelingDTO.destination = temporaryTraveling.destination;
            temporaryTravelingDTO.exitTime = temporaryTraveling.exitTime;
            temporaryTravelingDTO.arriveTime = temporaryTraveling.arriveTime;
            temporaryTravelingDTO.date = temporaryTraveling.date;
            return temporaryTravelingDTO;
        }

        public static temporaryTraveling ConvertToTemporaryTraveling(TemporaryTravelingDTO temporaryTravelingDTO)
        {
            temporaryTraveling temporaryTraveling = new temporaryTraveling();
            temporaryTraveling.id = temporaryTravelingDTO.id;
            temporaryTraveling.driverId = temporaryTravelingDTO.driverId;
            temporaryTraveling.source = temporaryTravelingDTO.source;
            temporaryTraveling.destination = temporaryTravelingDTO.destination;
            temporaryTraveling.exitTime = temporaryTravelingDTO.exitTime;
            temporaryTraveling.arriveTime = temporaryTravelingDTO.arriveTime;
            temporaryTraveling.date = temporaryTravelingDTO.date;
            return temporaryTraveling;
        }
    }
}
