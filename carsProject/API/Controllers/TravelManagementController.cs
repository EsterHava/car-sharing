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
    [RoutePrefix("api/TravelManagement")]
    public class TravelManagementController : ApiController
    {
        TravellerInRegularTravelBL travellerInBl = new TravellerInRegularTravelBL();
        TravelManagement manager = new TravelManagement();
        RegularTravelingBL travelingBL = new RegularTravelingBL();

        [HttpGet]
        [Route("GetRegularTravel")]
        public IEnumerable<RegularTravelingDTO> GetRegularTravel()
        {
            return travelingBL.GetTravel();
        }

        [HttpGet]
        [Route("GetRegularTravelByDriver")]
        public IEnumerable<RegularTravelingDTO> GetRegularTravelByDriver(string driverId)
        {
            return travelingBL.GetTravelByDriver(int.Parse(driverId));
        }

        [HttpPost]
        [Route("AddRegularTravel")]
        public bool AddRegularTravel([FromBody] RegularTravelingDTO travel)
        {
            return manager.AddRegularTravel(travel);
        }

        [HttpPost]
        [Route("DeleteRegularTravel")]
        public bool DeleteRegularTravel([FromBody]RegularTravelingDTO travel)
        {
            return manager.DeleteRegularTravel(travel);
        }

        [HttpPost]
        [Route("UpdateRegularTravel")]
        public bool UpdateRegularTravel([FromBody] RegularTravelingDTO travel)
        {
            return manager.UpdateRegularTravel(travel);
        }

        [HttpGet]
        [Route("GetTravelerTravelings/{travelerId}")]
        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerTravelingsByTraveller(string travelerId)
        {
            return travellerInBl.GetTravellerTravelingsByTraveller(int.Parse(travelerId));
        }

        [HttpPost]
        [Route("DeleteTravellerInTravel")]
        public bool deleteTraveller([FromBody] TravellerInRegularTravelDTO tr)
        {
            return manager.deleteTravelerInTravel(tr);
        }
    }
}
