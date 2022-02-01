using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BL
{
    public class UserBL
    {
        public static IEnumerable<UserDTO> GetUsers()
        {
            var list = UserDal.GetUsers();
            foreach (var item in list)
            {
                yield return Converts.UserConvert.ConvertToUserDTO(item);
            }
        }
        public static UserDTO GetUserByUserName(string userName)
        {
            var list = UserDal.GetUsers();
            foreach (var item in list)
            {
                if (item.userName == userName)
                    return Converts.UserConvert.ConvertToUserDTO(item);
            }
            return null;
        }

        public static UserDTO GetUserById(int id)
        {
            var list = UserDal.GetUsers();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.UserConvert.ConvertToUserDTO(item);
            }
            return null;
        }

        public static UserDTO UpdateUser(UserDTO user)
        {
            user u = UserDal.UpdateUser(Converts.UserConvert.ConvertToUser(user));
            if (u != null)
                return Converts.UserConvert.ConvertToUserDTO(u);
            return null;
        }
    }
}
