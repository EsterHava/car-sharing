using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class TravellerInRegularTravelBL
    {
        public static IEnumerable<TravellerInRegularTravelDTO> GetTravellerInRegularTravels()
        {
            var list = TravellerInRegularTravelDal.GetTravellerInRegularTravels();
            foreach (var item in list)
            {
                yield return Converts.TravellerInRegularTravelConvert.ConvertToTravellerInRegularTravelDTO(item);
            }

        }
    }
}
