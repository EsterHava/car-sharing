using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using DTO;
namespace API.Controllers
{

    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/JoinManagement")]
    public class JoinManagementController : ApiController
    {
        JoinRequestBL requestBL = new JoinRequestBL();
        JoinManagement manager = new JoinManagement();
        [HttpPost]
        [Route("join")]
        public bool JoinRequest([FromBody] JoinRequestDTO request)
        {
            return manager.joinRequest(request);
        }

        [HttpGet]
        [Route("getRequests")]
        public IEnumerable<JoinRequestDTO> GetRequestsByDriverId(string driverId)
        {
            return requestBL.GetRequestsByDriverId(int.Parse(driverId));
        }

        //search the travel
        [Route("search")]
        public IEnumerable<RegularTravelingDTO> Post(JoinRequestDTO request)
        {
            return manager.SearchTravels(request);
        }

        [Route("getTravel")]
        public RegularTravelingDTO GetTravelByRequestId(string reqId)
        {
            return requestBL.GetTravelByRequestId(int.Parse(reqId));
        }


        [HttpGet]
        [Route("approveRequest")]
        public bool ApproveRequest(string reqId,string isApprove)
        {
            return manager.ApproveRequest(int.Parse(reqId),bool.Parse(isApprove));
        }
    }
}
