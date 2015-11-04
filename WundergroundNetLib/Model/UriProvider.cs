using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WundergroundNetLib.Properties;

namespace WundergroundNetLib
{
    /// <summary>
    /// You will need to create your own Wunderground API key. 
    /// Learn more: http://www.wunderground.com/weather/api/d/docs 
    /// Add that key to a file called WundergroundApiKey.txt inside the folder called keys.
    /// Resources.WundergroundApiKey references the internal resource for that key
    /// </summary>
    public class UriProvider : IUriProvider
    {

        /// <summary>
        /// Create URI for conditions/forecast/astronomy based on your latitude and longitude.
        /// Ensure that you are providing latitude and longitude in the correct order as doubles.
        /// 
        /// This uri provider retrieves astronomy, forecast and conditions in one single call
        /// this reduces the number of api calls made to Wunderground, which lowers your subsription cost.
        /// </summary>
        /// <param name="dataFeatures"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public Uri CreateCombinedDataUriFromCoordinates(double latitude, double longitude)
        {
            // There needs to be a check here that the doubles provided are within the correct range (+- 90 // +-180)
            string geoLat = Convert.ToString(latitude);
            string geoLong = Convert.ToString(longitude);
            string coordinates = geoLat + "," + geoLong;
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/conditions/forecast/astronomy/q/{coordinates}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YOURKEYHERE/conditions/forecast/astronomy/q/-43.000000,172.000000.json
        }
        /// <summary>
        /// Create URI for conditions/forecast/astronomy based on your latitude and longitude.
        /// Ensure that you are providing latitude and longitude in the correct order as strings.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Uri CreateCombinedDataUriFromCoordinates(string latitude, string longitude)
        {
            // There should be a check here to ensure the strings provided are numeric values.
            // There needs to be a check to ensure the coordinates within the correct range.
            string coordinates = latitude + "," + longitude;
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/conditions/forecast/astronomy/q/{coordinates}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YOURKEYHERE/conditions/forecast/astronomy/q/-43.000000,172.000000.json
        }

        /// <summary>
        /// Create URI for conditions/forecast/astronomy based on your latitude and longitude.
        /// Ensure that you are providing latitude and longitude in the correct order as strings.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public Uri CreateCombinedDataUriFromPwsStationID(string stationID)
        {
            // There could be a regex here to check that the stationID meets certain requirements
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/conditions/forecast/astronomy/q/pws:{stationID}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YOURKEYHERE/conditions/forecast/astronomy/q/pws:ICANTERB275.json
        }
    }
}
