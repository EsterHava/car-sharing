using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDal
    {
        public static IEnumerable<user> GetUsers()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.user;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
        public static int AddUser(user user)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.user.Add(user);
                cp.SaveChanges();
                

                return user.id;
            }
            catch (Exception e)
            {
                return user.id;
            }
        }
        public static user UpdateUser(user user)
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                cp.Entry(user).State = System.Data.Entity.EntityState.Modified;
                cp.SaveChanges();
                return user;
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
