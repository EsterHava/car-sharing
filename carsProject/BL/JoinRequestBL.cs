using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BL
{
    public class JoinRequestBL
    {

        public static IEnumerable<JoinRequestDTO> GetRequestsByDriverId(int driverId) {

            var list = JoinRequestDal.GetRequests();
            foreach (var item in list)
            {
                //if ((item.regularTravelId != null && RegularTravelingBL.GetTravelById((int)item.regularTravelId).driverId == driverId ||
                //    item.temporaryTravelId != null && TemporaryTravelingBL.GetTravelById((int)item.temporaryTravelId).driverId == driverId)){
                //    yield return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(item);

                //}
                if ((item.regularTravelId != null && RegularTravelingBL.GetTravelById((int)item.regularTravelId).driverId == driverId))
                {
                    yield return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(item);

                }
            }
        }

        public static bool AddRequest(JoinRequestDTO request)
        {
            return JoinRequestDal.AddRequest
                (Converts.JoinRequestConvert.ConvertToJoinRequest(request));
        }
        public static JoinRequestDTO AddAndReturnRequest(JoinRequestDTO request)
        {
            return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(JoinRequestDal.AddAndReturnRequest
                (Converts.JoinRequestConvert.ConvertToJoinRequest(request)));
        }
        public static bool DeleteRequest(int requestId) {
           return JoinRequestDal.DeleteRequest(requestId);
        }

    }
}
