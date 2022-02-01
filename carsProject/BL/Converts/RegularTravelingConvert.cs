﻿using System;
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
            return regularTraveling;
        }
    }
}
