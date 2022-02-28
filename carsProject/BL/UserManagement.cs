using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BL
{
    public class UserManagement
    {
        public static UserDTO Login(string userName, string password)
        {
            foreach (var item in UserBL.GetUsers())
            {
                if (item.userName.Equals(userName) && item.password.Equals(password))
                    return item;
            }
            return null;
        }
        public static bool Register(UserDTO user)
        {
            int userId = UserDal.AddUser(Converts.UserConvert.ConvertToUser(user));
            if (userId==0)
            {
                return false;
            }
            else
            {
                SendEmail(userId);
            }
            return true;

        }
        public static UserDTO UpdateUser(UserDTO user)
        {
            return UserBL.UpdateUser(user);
        }

        public static string GetUserNameById(int id)
        {
            UserDTO u = UserBL.GetUserById(id);
            return u.firstName + " " + u.lastName;
        }

        public static bool SendEmail(int userId)
        {
            UserDTO user = UserBL.GetUserById(userId);

            string Subject = "ברוכים הבאים";
            string Body = string.Format("שמחים שהצטרפת אלינו");
            return ActivityGeneral.SendEmail(user.mail, Subject, Body);

        }
    }
}
