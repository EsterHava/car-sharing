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
        //
        [HttpPost]
        [Route("join")]
        public bool JoinRequest([FromBody] JoinRequestDTO request)
        {
            return JoinManagement.joinRequest(request);
        }

        [HttpGet]
        [Route("getRequests")]
        public IEnumerable<JoinRequestDTO> GetRequestsByDriverId(string driverId) {
            return JoinRequestBL.GetRequestsByDriverId(int.Parse(driverId));
        }
        
        //search the travel
        [Route("search")]
        public IEnumerable<RegularTravelingDTO> Post(JoinRequestDTO request)
        {
            return JoinManagement.SearchTravels(request);
        }


    }
}
