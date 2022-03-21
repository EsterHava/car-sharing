using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Device.Location;

namespace BL
{
    public class JoinManagement
    {
        MessagesManagement manager = new MessagesManagement();
        JoinRequestBL requestBL = new JoinRequestBL();
        RegularTravelingBL travelingBL = new RegularTravelingBL();
        // private string message = ' {יש לך בקשת הצטרפות לנסיעה מס {0';

        public bool joinRequest(JoinRequestDTO request)
        {
            JoinRequestDTO rDTO = requestBL.AddRequestNotExist(request);

            int driverId = 0;
            if (rDTO != null)
            {
                try
                {
                    //int driverId = request.regularTravelId == null ? (int)TemporaryTravelingBL.GetTravelById((int)request.temporaryTravelId).driverId
                    //: (int)RegularTravelingBL.GetTravelById((int)request.regularTravelId).driverId;
                    driverId = (int)travelingBL.GetTravelById((int)request.regularTravelId).driverId;
                    string subject = "יש לך בקשת הצטרפות נסיעה חדשה";
                    string body = string.Format("יש לך בקשת הצטרפות לנסיעה\n " +
                                " אנא הכנס לאזורך האישי\n " +
                                " כדי לאשר.\n" +
                                "מצורף בזה קישור\n" +
                                "http://localhost:4200/main/messages");
                    SendEmail(driverId, subject, body);
                    //SendEmail(driverId);           
                    return manager.CreateMessageNewReq(rDTO, driverId);

                }
                catch (Exception ex)
                {
                    requestBL.DeleteRequest(rDTO.id);
                    return false;
                }
            }
            return false;
        }

        //method that search a travvel for the passenger according the request
        public List<RegularTravelingDTO> SearchTravels(JoinRequestDTO joinRequest)
        {
            TravellerInRegularTravelBL travellerInBl = new TravellerInRegularTravelBL();
            List<RegularTravelingDTO> RegularTravelingList = new List<RegularTravelingDTO>();
            List<RegularTravelingDTO> RegularTravelingListFiltered = new List<RegularTravelingDTO>();

            RegularTravelingList = travelingBL.GetTravel().ToList();

            Location locationSourceRequest = GoogleMapService.getPosition(joinRequest.Source);
            Location locationDestinationRequest = GoogleMapService.getPosition(joinRequest.Destination);

            foreach (var item in RegularTravelingList)
            {
                //האם לנסיעה הזאת יש מקום פנוי
                int countTravellerInRegularTravel = travellerInBl.GetTravellerInRegularTravelsByTravelId(item.id).Count();
                if (item.availableSeats <= countTravellerInRegularTravel)
                    continue;

                if (item.latSourcr != null && item.longSource != null && item.latDestination != null && item.longDestination != null)
                {
                    var sourceCoordTraveling = new GeoCoordinate((double)item.latSourcr, (double)item.longSource);
                    var sourceCoordRequest = new GeoCoordinate(locationSourceRequest.lat, locationSourceRequest.lng);

                    var destinationCoordTraveling = new GeoCoordinate((double)item.latDestination, (double)item.longDestination);
                    var destinationCoordRequest = new GeoCoordinate(locationDestinationRequest.lat, locationDestinationRequest.lng);

                    double distanceSource = sourceCoordTraveling.GetDistanceTo(sourceCoordRequest) / 1000;
                    double distanceDestination = destinationCoordTraveling.GetDistanceTo(destinationCoordRequest) / 1000;

                    TimeSpan span = ((TimeSpan)item.exitTime).Subtract(joinRequest.TimeEixt);
                    string[] days = joinRequest.dayList.Split(',');
                    if (distanceSource <= joinRequest.SourceRange && distanceDestination <= joinRequest.DestinationsRange && Math.Abs(span.TotalMinutes) <= joinRequest.TimeRange && days.ToList().Contains(item.day.ToString()))
                    {
                        RegularTravelingDTO Traveling = new RegularTravelingDTO();
                        Traveling = item;
                        Traveling.longDestinationRequest = locationDestinationRequest.lng;
                        Traveling.latDestinationRequest = locationDestinationRequest.lat;
                        Traveling.longSourceRequest = locationSourceRequest.lng;
                        Traveling.latSourceRequest = locationSourceRequest.lat;
                        RegularTravelingListFiltered.Add(Traveling);
                    }
                }
            }

            return RegularTravelingListFiltered;
        }

        public bool ApproveRequest(int reqId, bool isApprove)
        {
            TravellerInRegularTravelBL travellerInBl = new TravellerInRegularTravelBL();
            JoinRequestDTO request = requestBL.GetRequestById(reqId);
            RegularTravelingDTO travel = requestBL.GetTravelByRequestId(request.id);
            string subject;
            string body;

            if (isApprove)
            {
                subject = "בקשתך להצטרפות לנסיעה אושרה";
                body = " ! בקשתך להצטרפות לנסיעה מ-{0} ל-{1} ביום: {2} אושרה" +
                    " הנך יכול להכנס לצפות בנסיעות שאתה מצורף אליהן" +
                    "http://localhost:4200/main/tableForTraveller";
                travellerInBl.AddTraveller(request);
            }
            else
            {
                subject = "בקשתך להצטרפות לנסיעה לא אושרה";
                body = " ! בקשתך להצטרפות לנסיעה מ-{0} ל-{1} ביום: {2} לא אושרה" +
                   " הנך יכול להכנס לאתר ולחפש נסיעות נוספות" +
                   "http://localhost:4200/main/tableForTraveller";
            }
            body = string.Format(body, travel.day, travel.source, travel.destination);
            SendEmail(request.userId, subject, body);
            return requestBL.DeleteRequest(request.id);
        }


        private bool SendEmail(int userId, string subject, string body)
        {
            UserDTO recipient = UserBL.GetUserById(userId);
            return ActivityGeneral.SendEmail(recipient.mail, subject, body);
        }





















        //public static bool SendEmail()
        //{

        //    // copied from https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient.send?view=net-5.0
        //    string to = "esterhava@gmail.com";
        //    string from = "carsharing62@gmail.com";
        //    MailMessage message = new MailMessage(from, to);
        //    message.Subject = "welcom to car sharing";
        //    message.Body = "hello!!!!!";

        //    SmtpClient client = new SmtpClient("smtp.gmail.com");
        //    // Credentials are necessary if the server requires the client
        //    // to authenticate before it will send email on the client's behalf.
        //    NetworkCredential nc = new NetworkCredential(from, "0548594162");
        //    client.Credentials = nc;
        //    client.UseDefaultCredentials = true;
        //    client.EnableSsl = true;
        //    client.Port = 587;
        //    client.UseDefaultCredentials = false;

        //    try
        //    {
        //        client.Send(message);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception caught in CreateTestMessage2(): {0}",
        //            ex.ToString());
        //        return false;
        //    }
        //}
    }
}
