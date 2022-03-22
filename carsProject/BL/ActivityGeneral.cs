using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    class ActivityGeneral
    {
        public static bool SendEmail(string toAddress="",string subject="",string body="")
        {
            const string from = "carsharing62@gmail.com";
            var fromAddr = new MailAddress(from, "car Sharing");
            var toAddr = new MailAddress(toAddress);
            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Timeout = 30 * 1000,
                Credentials = new NetworkCredential(fromAddr.Address, "0548594162")
            };
            try
            {
                using (var msg = new MailMessage(fromAddr, toAddr))
                {
                    msg.Subject = subject;
                    msg.Body = body;
                    client.Send(msg);
                }
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}
