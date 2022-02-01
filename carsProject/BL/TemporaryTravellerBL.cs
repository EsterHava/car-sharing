using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class TemporaryTravellerBL
    {
        public static IEnumerable<TemporaryTravellerDTO> GetTemporaryTravellers()
        {
            var list = TemporaryTravellerDal.GetTemporaryTravellers();
            foreach (var item in list)
            {
                yield return Converts.TemporaryTravellerConvert.ConvertToTemporaryTravellerDTO(item);
            }

        }
    }
}
