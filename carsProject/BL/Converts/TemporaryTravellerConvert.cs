using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL.Converts
{
    public static class TemporaryTravellerConvert
    {

        public static TemporaryTravellerDTO ConvertToTemporaryTravellerDTO(temporaryTraveller temporaryTraveller)
        {
            TemporaryTravellerDTO temporaryTravellerDTO = new TemporaryTravellerDTO();
            temporaryTravellerDTO.id = temporaryTraveller.id;
            temporaryTravellerDTO.date = temporaryTraveller.date;
            temporaryTravellerDTO.travelId = temporaryTraveller.travelId;
            temporaryTravellerDTO.travellerId = temporaryTraveller.travellerId;
            temporaryTravellerDTO.collectionPoint = temporaryTraveller.collectionPoint;
            temporaryTravellerDTO.destinationPoint = temporaryTraveller.destinationPoint;
            temporaryTravellerDTO.isRegular = temporaryTraveller.isRegular;
            return temporaryTravellerDTO;
        }
        public static temporaryTraveller ConvertToTemporaryTraveller(TemporaryTravellerDTO temporaryTravellerDTO)
        {
            temporaryTraveller temporaryTraveller = new temporaryTraveller();
            temporaryTraveller.id = temporaryTravellerDTO.id;
            temporaryTraveller.date = temporaryTravellerDTO.date;
            temporaryTraveller.travelId = temporaryTravellerDTO.travelId;
            temporaryTraveller.travellerId = temporaryTravellerDTO.travellerId;
            temporaryTraveller.collectionPoint = temporaryTravellerDTO.collectionPoint;
            temporaryTraveller.destinationPoint = temporaryTravellerDTO.destinationPoint;
            temporaryTraveller.isRegular = temporaryTravellerDTO.isRegular;
            return temporaryTraveller;
        }
    }
}
