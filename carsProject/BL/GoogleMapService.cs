using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace BL
{
    public class GoogleMapService
    {
        public static Location getPosition(string address)
        {
            address = address + " ישראל";
            string url = WebConfigurationManager.AppSettings["Url"];
            string key = WebConfigurationManager.AppSettings["Key"];

            string googleUrl = url + "?address={HttpUtility.UrlEncode(" + address + ")}&key=" + key;
            WebClient webClient = new WebClient();
            string googleContent = webClient.DownloadString(googleUrl);

            string googleContentTrim = googleContent.Replace(" ", "").Replace("\n", "");
            int lngFrom = googleContentTrim.IndexOf("\"lng\":") + "\"lng\":".Length;
            int lngTo = googleContentTrim.Substring(lngFrom).IndexOf("}") + lngFrom;

            int latFrom = googleContentTrim.IndexOf("\"lat\":") + "\"lat\":".Length;
            int latTo = googleContentTrim.Substring(latFrom).IndexOf(",") + latFrom;

            return new Location { lat = Double.Parse(googleContentTrim.Substring(latFrom, latTo - latFrom)), lng = Double.Parse(googleContentTrim.Substring(lngFrom, lngTo - lngFrom)) };
        }

    }
}
