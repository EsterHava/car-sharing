using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public  class GenderDal
    {
        public static IEnumerable<gender> GetGenders()
        {
            try
            {
                car_projectEntities cp = new car_projectEntities();
                return cp.gender;
            }
            catch (Exception e)
            {//todo log
                throw new Exception(e.Message);

            }
        }
    }
}
