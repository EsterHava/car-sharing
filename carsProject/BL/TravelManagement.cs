using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BL
{
    public class TravelManagement
    {
        public static bool AddRegularTravel(RegularTravelingDTO travel)
        {//בדיקות ולידציה
            return RegularTravelingBL.AddTravel(travel);
        }
        public static bool AddTemporaryTravel(TemporaryTravelingDTO travel)
        {
            //בדיקות ולידציה
            return TemporaryTravelingBL.AddTravel(travel);
        }
        public static bool DeleteRegularTravel(RegularTravelingDTO travel)
        {
            return RegularTravelingBL.DeleteTravel(travel.id);
        }
        public static bool DeleteTemporaryTravel(TemporaryTravelingDTO travel)
        {
            return TemporaryTravelingBL.DeleteTravel(travel.id);
        }
        public static bool UpdateRegularTravel(RegularTravelingDTO travel)
        {
            return RegularTravelingBL.UpdateTravel(travel);
        }
        public static bool UpdateTemporaryTravel(TemporaryTravelingDTO travel)
        {
            return TemporaryTravelingBL.UpdateTravel(travel);
        }
    }
}
