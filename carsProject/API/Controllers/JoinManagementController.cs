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
    public class JoinManagementController : ApiController
    {
        [HttpPost]
        [Route("api/JoinManagement/join")]
        public bool JoinRequest([FromBody] JoinRequestDTO request)
        {
            return JoinManagement.joinRequest(request);
        }
        [HttpGet]
        [Route("api/JoinManagement/getRequests")]
        public IEnumerable<JoinRequestDTO> GetRequestsByDriverId(string driverId) {
            return JoinRequestBL.GetRequestsByDriverId(int.Parse(driverId));
        }


        // GET: api/JoinManagement
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/JoinManagement/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/JoinManagement
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/JoinManagement/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/JoinManagement/5
        public void Delete(int id)
        {
        }
    }
}
