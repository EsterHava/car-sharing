using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL.Converts
{
    class JoinRequestConvert
    {
        public static JoinRequestDTO ConvertToJoinRequestDTO(joinRequests JoinRequest)
        {
            JoinRequestDTO JoinRequestDTO = new JoinRequestDTO();
            JoinRequestDTO.id = JoinRequest.id;
            JoinRequestDTO.userId = JoinRequest.userId;
            JoinRequestDTO.Date = JoinRequest.Date;
            JoinRequestDTO.regularTravelId = JoinRequest.regularTravelId;
            JoinRequestDTO.temporaryTravelId = JoinRequest.temporaryTravelId;

            return JoinRequestDTO;
        }
        public static joinRequests ConvertToJoinRequest(JoinRequestDTO JoinRequestDTO)
        {
            joinRequests JoinRequest = new joinRequests();
            JoinRequest.id = JoinRequestDTO.id;
            JoinRequest.userId = JoinRequestDTO.userId;
            JoinRequest.Date = JoinRequestDTO.Date;
            JoinRequest.regularTravelId = JoinRequestDTO.regularTravelId;
            JoinRequest.temporaryTravelId = JoinRequestDTO.temporaryTravelId;
            return JoinRequest;
        }





    }
}
