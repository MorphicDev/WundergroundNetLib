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
    public class UriProvider
    {
        /// <summary>
        /// This the currently used Uri Provider. However the /pws/ between wunApiKey is redundant
        /// this will need to be removed which will alter the wunderground objects, however it could be worth
        /// reconsidering how we deserialise the JSON files, to map them to specific objects to suit out purpose
        /// changing the way the data is provided
        /// </summary>
        /// <param name="dataFeatures"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        public Uri CreateUriFromPwsLocationForSpecificFeature(WunDataFeatures dataFeatures, string location)
        {
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/pws/{dataFeatures}/q/pws:{location}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YourApiKey/pws/conditions/q/pws:ISOUTHLA34.json
        }

        /// <summary>
        /// This is the most recent uri provider which retrieves astronomy, forecast and conditions in one single call
        /// this reduces the number of api calls made to Wunderground, which in tern lowers your subsription cost.
        /// Note that this uri has the unneeded /pws/ removed from the uri. 
        /// 
        /// Classes to match this JSON file will need to be created. LINQ to JSON could be the technology of choice.
        /// Also methods to call this method will need to be created, which pass in the coordinates as a single string.
        /// If needed this method could be refactored to take two doubles (the largest number of digits for a longitude
        /// value would be 9 plus the '-' sign
        /// </summary>
        /// <param name="dataFeatures"></param>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        public Uri CreateUriFromCoordinatesForAstroCondForecast(string coordinates)
        {
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/astronomy/forecast/conditions/q/{coordinates}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YOURKEYHERE/astronomy/forecast/conditions/q/-43.000000,172.000000.json
        }
    }
}
