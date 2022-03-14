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
    public class UserManagementController : ApiController
    {
        [HttpGet]
        [Route("api/UserManagement/GetUserByUserName")]
        public UserDTO GetUserByUserName(string userName)
        {
            return UserBL.GetUserByUserName(userName);
        }

        [HttpGet]
        [Route("api/UserManagement/GetUserByUserId")]
        public UserDTO GetUserByUserId(string id)
        {
            return UserBL.GetUserByUserId(id);
        }
 
        [HttpGet]
        [Route("api/UserManagement/GetUserNameById")]
        public string GetUserNameById(string id)
        {
            return UserManagement.GetUserNameById(int.Parse(id));
        }

        [HttpPost]
        [Route("api/UserManagement/Login")]
        public UserDTO Login([FromBody]UserDTO user)
        {
            return UserManagement.Login(user.userName, user.password);
        }

        [HttpPost]
        [Route("api/UserManagement/Register")]
        public bool Register([FromBody]UserDTO user)
        {
            return UserManagement.Register(user);
        }

        [HttpPost]
        [Route("api/UserManagement/UpdateUser")]
        public UserDTO UpdateUser([FromBody]UserDTO user)
        {
            return UserManagement.UpdateUser(user);
        }

        [HttpPost]
        [Route("api/UserManagement/AddCar")]
        public bool AddCar([FromBody]CarDTO car)
        {
            return CarManagement.AddCar(car);
        }

        [HttpGet]
        [Route("api/UserManagement/GetMessages")]
        public IEnumerable<MessagesDTO> GetMessages(string userId)
        {
            return MessagesManagement.GetMessages(userId);
        }
    }
}
