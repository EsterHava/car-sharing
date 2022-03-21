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
        TravellerInRegularTravelBL travelBL = new TravellerInRegularTravelBL();
        RegularTravelingBL regularTrBl = new RegularTravelingBL();
        MessagesManagement msgManager = new MessagesManagement();
        public bool AddRegularTravel(RegularTravelingDTO travel)
        {
            return regularTrBl.AddTravel(travel);
        }

        public bool DeleteRegularTravel(RegularTravelingDTO travel)
        {
            string subject = "נסיעה שהנך מצורף אליה התבטלה";
            string body = string.Format("נסיעה שאתה מצורף אליה התבטלה\n" +
                                        "אנא הכנס לאתר כדי לראות פרטים נוספים\n" +
                                        "http://localhost:4200/main/messages");
            var list = travelBL.GetTravellerInRegularTravelsByTravelId(travel.id);
            foreach(TravellerInRegularTravelDTO item in list){
                msgManager.CreateMessageDeleteTravel((int)item.travelerId);
            }
            return regularTrBl.DeleteTravel(travel.id);
        }

        public bool UpdateRegularTravel(RegularTravelingDTO travel)
        {
            return regularTrBl.UpdateTravel(travel);
        }

        public bool deleteTravelerInTravel(TravellerInRegularTravelDTO tr)
        {
            RegularTravelingDTO travel = regularTrBl.GetTravelById((int)tr.regularTravelingId);
            try
            {
                string body = "נוסע בטל הצטרפות לנסיעה ביום  מ- ל- ";
                string subject = "סכגחלךףף,";
                return SendEmail((int)travel.driverId, subject, body) && travelBL.deleteTraveller(tr);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool SendEmail(int userId, string subject, string body)
        {
            UserDTO recipient = UserBL.GetUserById(userId);
            return ActivityGeneral.SendEmail(recipient.mail, subject, body);
        }

    }
}
