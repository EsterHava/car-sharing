using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class GenderBL
    {
        public static IEnumerable<GenderDTO> GetGenders()
        {
            var list = GenderDal.GetGenders();
            foreach (var item in list)
            {
                yield return Converts.GenderConvert.ConvertToGenderDTO(item);
            }

        }
    }
}
