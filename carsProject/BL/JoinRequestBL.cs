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
        JoinRequestDal requestDal = new JoinRequestDal();
        TravellerInRegularTravelDal travellerDal = new TravellerInRegularTravelDal();
        RegularTravelingBL travelingBL = new RegularTravelingBL();

        //return all the join to travel request of the passenger that not approve yet
        public IEnumerable<JoinRequestDTO> GetRequestsByDriverId(int driverId)
        {

            var list = requestDal.GetRequests();
            foreach (var item in list)
            {
                if ((item.regularTravelId != null && travelingBL.GetTravelById((int)item.regularTravelId).driverId == driverId))
                {
                    yield return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(item);

                }
            }
        }

        public JoinRequestDTO GetRequestById(int reqId)
        {
            var list = requestDal.GetRequests();
            foreach (var item in list)
            {
                if (item.id == reqId)
                    return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(item);
            }
            return null;
        }

        //add a join request to DB
        public bool AddRequest(JoinRequestDTO request)
        {
            return requestDal.AddRequest
                (Converts.JoinRequestConvert.ConvertToJoinRequest(request));
        }

        public JoinRequestDTO AddRequestNotExist(JoinRequestDTO request)
        {
            if (IsRequestExist(request.userId, (int)request.regularTravelId))
            {
                return null;
            }
            return Converts.JoinRequestConvert.ConvertToJoinRequestDTO(requestDal.AddAndReturnRequest
                    (Converts.JoinRequestConvert.ConvertToJoinRequest(request)));
        }

        public bool DeleteRequest(int requestId)
        {
            return requestDal.DeleteRequest(requestId);
        }

        public RegularTravelingDTO GetTravelByRequestId(int reqId)
        {
            var reqList = requestDal.GetRequests();
            foreach (var item in reqList)
            {
                if (item.id == reqId)
                {
                    return travelingBL.GetTravelById((int)item.regularTravelId);
                }
            }
            return null;
        }
        private bool IsRequestExist(int userId, int travelId)
        {
            var list = requestDal.GetRequests();
            List<JoinRequestDTO> requestList = new List<JoinRequestDTO>();
            foreach (var item in list)
            {
                if (item.userId == userId && item.regularTravelId == travelId)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
