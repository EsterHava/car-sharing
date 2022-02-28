using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using System.Web.Configuration;
using System.Web;
using System.Net;
using System.Xml.Linq;

namespace BL
{
    public class RegularTravelingBL
    {
        public static IEnumerable<RegularTravelingDTO> GetTravel()
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }

        }
        public static IEnumerable<RegularTravelingDTO> GetTravelByDriver(int driverId)
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.driverId == driverId)
                    yield return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);
            }

        }
        public static RegularTravelingDTO GetTravelById(int id)
        {
            var list = RegularTravelingDal.GetTravel();
            foreach (var item in list)
            {
                if (item.id == id)
                    return Converts.RegularTravelingConvert.ConvertToRegularTravelingDTO(item);

            }
            return null;

        }
        public static bool AddTravel(RegularTravelingDTO travel)
        {
            Location locationSource=new Location();
            locationSource = getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = getPosition(travel.destination);
            travel.latDestination = locationDestination.lat;
            travel.latDestination = locationDestination.lng;

            return RegularTravelingDal.AddTravel
            (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }
        private static Location getPosition(string address)
        {
            string url = WebConfigurationManager.AppSettings["Url"];
            string key = WebConfigurationManager.AppSettings["Key"];

            string googleUrl = url + "?address={HttpUtility.UrlEncode(" + address + ")}&key=" + key;
            WebClient webClient = new WebClient();
            string googleContent = webClient.DownloadString(googleUrl);

           string googleContentTrim=googleContent.Replace(" ", "").Replace("\n","");
            int lngFrom = googleContentTrim.IndexOf("\"lng\":") + "\"lng\":".Length;
            int lngTo = googleContentTrim.Substring(lngFrom).IndexOf("}")+ lngFrom;

            int latFrom = googleContentTrim.IndexOf("\"lat\":") + "\"lat\":".Length;
            int latTo = googleContentTrim.Substring(latFrom).IndexOf(",")+ latFrom;

            return new Location { lat = Double.Parse(googleContentTrim.Substring(latFrom, latTo - latFrom)), lng = Double.Parse(googleContentTrim.Substring(lngFrom, lngTo - lngFrom)) };

            //GoogleGeocodeServiceResponse result = JsonConvert.DeserializeObject<GoogleGeocodeServiceResponse>(googleContent);
            //if (result.status == "OK")
            //{
            //    if (result.results.Length > 0)
            //        foreach (var point in result.results)
            //        {
            //            decimal lat = point.geometry.location.lat;
            //            decimal lng = point.geometry.location.lng;
            //            return new Location { lat = lat, lng = lng };
            //        }
            //}


        }
        public static bool DeleteTravel(int travelId)
        {
            return RegularTravelingDal.DeleteTravel(travelId);
        }
        public static bool UpdateTravel(RegularTravelingDTO travel)
        {
            Location locationSource = getPosition(travel.source);
            travel.latSourcr = locationSource.lat;
            travel.longSource = locationSource.lng;

            Location locationDestination = getPosition(travel.destination);
            travel.latSourcr = locationDestination.lat;
            travel.longSource = locationDestination.lng;

            return RegularTravelingDal.UpdateTravel
                (Converts.RegularTravelingConvert.ConvertToRegularTraveling(travel));
        }
    }
}
