using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL.Converts
{
   public static class UserConvert
    {
        public static UserDTO ConvertToUserDTO(user user)
        {
            UserDTO userDTO = new UserDTO();
            userDTO.id = user.id;
            userDTO.firstName = user.firstName;
            userDTO.lastName = user.lastName;
            userDTO.userName = user.userName;
            userDTO.password = user.password;
            userDTO.tel = user.tel;
            userDTO.mail = user.mail;
            userDTO.genderId = user.genderId;
            userDTO.points = user.points;
            userDTO.isHasCar = user.isHasCar;
            return userDTO;
        }
        public static user ConvertToUser(UserDTO userDTO)
        {
           user user = new user();
            user.id = userDTO.id;
            user.firstName = userDTO.firstName;
            user.lastName = userDTO.lastName;
            user.userName = userDTO.userName;
            user.password = userDTO.password;
            user.tel = userDTO.tel;
            user.mail = userDTO.mail;
            user.genderId = userDTO.genderId;
            user.points = userDTO.points;
            user.isHasCar = userDTO.isHasCar;
            return user;
        }

    }
}
