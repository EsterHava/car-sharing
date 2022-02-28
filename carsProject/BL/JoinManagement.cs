using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BL
{
    public class JoinManagement
    {

        public static bool joinRequest(JoinRequestDTO request)
        {
            JoinRequestDTO rDTO = JoinRequestBL.AddAndReturnRequest(request);
            if (rDTO != null)
            {
                try
                {
                    int driverId = request.regularTravelId == null ? (int)TemporaryTravelingBL.GetTravelById((int)request.temporaryTravelId).driverId
                    : (int)RegularTravelingBL.GetTravelById((int)request.regularTravelId).driverId;
                    SendEmail(driverId);
                }
                catch (Exception)
                {
                    JoinRequestBL.DeleteRequest(rDTO.id);
                    return false;
                }
            }
            return true;
        }
        public static List<RegularTravelingDTO> SearchTravels(JoinRequestDTO joinRequest)
        {
            return null;
        }
        public static bool SendEmail(int driverId)
        {
            UserDTO driver = UserBL.GetUserById(driverId);

            string Subject = "יש לך בקשת הצטרפות נסיעה חדשה";
            string Body = string.Format("יש לך בקשת הצטרפות לנסיעה\n " +
                        " אנא הכנס לאזורך האישי\n " +
                        " כדי לאשר.\n" +
                        "מצורף בזה קישור\n" +
                        "http://localhost:4200/privateArea/" + driverId);
            return ActivityGeneral.SendEmail(driver.mail, Subject, Body);



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
