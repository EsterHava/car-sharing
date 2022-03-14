using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DTO;
using BL;

namespace API.Controllers
{
    [System.Web.Http.Cors.EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TravelManagementController : ApiController
    {

        [HttpGet]
        [Route("api/TravelManagement/GetRegularTravel")]
        public IEnumerable<RegularTravelingDTO> GetRegularTravel()
        {
            return RegularTravelingBL.GetTravel();
        }

            [HttpGet]
        [Route("api/TravelManagement/GetRegularTravelByDriver")]
        public IEnumerable<RegularTravelingDTO> GetRegularTravelByDriver(string driverId)
        {
            return RegularTravelingBL.GetTravelByDriver(int.Parse(driverId));
        }
      
        [HttpPost]
        [Route("api/TravelManagement/AddRegularTravel")]
        public bool AddRegularTravel([FromBody] RegularTravelingDTO travel)
        {
            return TravelManagement.AddRegularTravel(travel);
        }

        [HttpPost]
        [Route("api/TravelManagement/DeleteRegularTravel")]
        public bool DeleteRegularTravel([FromBody]RegularTravelingDTO travel)
        {
            return TravelManagement.DeleteRegularTravel(travel);
        }

        [HttpPost]
        [Route("api/TravelManagement/UpdateRegularTravel")]
        public bool UpdateRegularTravel([FromBody]RegularTravelingDTO travel)
        {
            return TravelManagement.UpdateRegularTravel(travel);
        }

        [HttpGet]
        [Route("api/TravelManagement/GetTravelerTravelings/{travelerId}")]
        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerTravelingsByTraveller(string travelerId)
        {
            return TravellerInRegularTravelBL.GetTravellerTravelingsByTraveller(int.Parse(travelerId));
        }
     
    }
}
