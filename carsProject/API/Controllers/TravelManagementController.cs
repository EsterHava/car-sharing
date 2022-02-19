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
        [Route("api/TravelManagement/GetTemporaryTravel")]
        public IEnumerable<TemporaryTravelingDTO> GetTemporaryTravl()
        {
            return TemporaryTravelingBL.GetTravel();
        }

        [HttpGet]
        [Route("api/TravelManagement/GetRegularTravelByDriver")]
        public IEnumerable<RegularTravelingDTO> GetRegularTravelByDriver(string driverId)
        {
            return RegularTravelingBL.GetTravelByDriver(int.Parse(driverId));
        }
        [HttpGet]
        [Route("api/TravelManagement/GetTemporaryTravelByDriver")]
        public IEnumerable<TemporaryTravelingDTO> GetTemporaryTravelByDriver(string driverId)
        {
            return TemporaryTravelingBL.GetTravelByDriver(int.Parse(driverId));
        }
        [HttpPost]
        [Route("api/TravelManagement/AddRegularTravel")]
        public bool AddRegularTravel([FromBody] RegularTravelingDTO travel)
        {
            return TravelManagement.AddRegularTravel(travel);
        }

        [HttpPost]
        [Route("api/TravelManagement/AddTemporaryTravel")]
        public bool AddTemporaryTravel([FromBody] TemporaryTravelingDTO travel)
        {
            return TravelManagement.AddTemporaryTravel(travel);
        }

        //todo:http.... ask
        [HttpPost]
        [Route("api/TravelManagement/DeleteRegularTravel")]
        public bool DeleteRegularTravel([FromBody]RegularTravelingDTO travel)
        {
            return TravelManagement.DeleteRegularTravel(travel);
        }

        //todo:http.... ask
        [HttpPost]
        [Route("api/TravelManagement/DeleteTemporaryTravel")]
        public bool DeleteTemporaryTravel([FromBody]TemporaryTravelingDTO travel)
        {
            return TravelManagement.DeleteTemporaryTravel(travel);
        }

        [HttpPost]
        [Route("api/TravelManagement/UpdateRegularTravel")]
        public bool UpdateRegularTravel([FromBody]RegularTravelingDTO travel)
        {
            return TravelManagement.UpdateRegularTravel(travel);
        }
        [HttpPost]
        [Route("api/TravelManagement/UpdateTemporaryTravel")]
        public bool UpdateTemporaryTravel([FromBody]TemporaryTravelingDTO travel)
        {
            return TravelManagement.UpdateTemporaryTravel(travel);
        }
        [HttpGet]
        [Route("api/TravelManagement/GetTravelerTravelings/{travelerId}")]
        public IEnumerable<TravellerInRegularTravelDTO> GetTravellerTravelingsByTraveller(string travelerId)
        {
            return TravellerInRegularTravelBL.GetTravellerTravelingsByTraveller(int.Parse(travelerId));
        }
        // GET: api/TravelManagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/TravelManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/TravelManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TravelManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TravelManagement/5
        public void Delete(int id)
        {
        }
    }
}
