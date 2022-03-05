using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL.Converts
{

    public static class RegularTravelingConvert
    {
        public static RegularTravelingDTO ConvertToRegularTravelingDTO(regularTraveling regularTraveling)
        {
            RegularTravelingDTO temporaryTravelingDTO = new RegularTravelingDTO();
            temporaryTravelingDTO.id = regularTraveling.id;
            temporaryTravelingDTO.driverId = regularTraveling.driverId;
            temporaryTravelingDTO.source = regularTraveling.source;
            temporaryTravelingDTO.destination = regularTraveling.destination;
            temporaryTravelingDTO.exitTime = regularTraveling.exitTime;
            temporaryTravelingDTO.arriveTime = regularTraveling.arriveTime;
            temporaryTravelingDTO.day = regularTraveling.day;
            temporaryTravelingDTO.latDestination = regularTraveling.latDestination;
            temporaryTravelingDTO.latSourcr = regularTraveling.latSource;
            temporaryTravelingDTO.longDestination = regularTraveling.lngDestination;
            temporaryTravelingDTO.longSource = regularTraveling.lngSource;
            temporaryTravelingDTO.availableSeats = regularTraveling.availableSeats;
            return temporaryTravelingDTO;
        }
        public static regularTraveling ConvertToRegularTraveling(RegularTravelingDTO temporaryTravelingDTO)
        {
            regularTraveling regularTraveling = new regularTraveling();
            regularTraveling.id = temporaryTravelingDTO.id;
            regularTraveling.driverId = temporaryTravelingDTO.driverId;
            regularTraveling.source = temporaryTravelingDTO.source;
            regularTraveling.destination = temporaryTravelingDTO.destination;
            regularTraveling.exitTime = temporaryTravelingDTO.exitTime;
            regularTraveling.arriveTime = temporaryTravelingDTO.arriveTime;
            regularTraveling.day = temporaryTravelingDTO.day;
            regularTraveling.latDestination = temporaryTravelingDTO.latDestination;
            regularTraveling.latSource = temporaryTravelingDTO.latSourcr;
            regularTraveling.lngDestination = temporaryTravelingDTO.longDestination;
            regularTraveling.lngSource = temporaryTravelingDTO.longSource;
            regularTraveling.availableSeats = temporaryTravelingDTO.availableSeats;

            return regularTraveling;
        }

        //from dal List to DTO list
        public static List<RegularTravelingDTO> ToDTOList(List<regularTraveling> dalList)
        {
            List<RegularTravelingDTO> dtoList = new List<RegularTravelingDTO>();
            dalList.ForEach(o => dtoList.Add(ConvertToRegularTravelingDTO(o)));
                return dtoList;
        }
    }
}
