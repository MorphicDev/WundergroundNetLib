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
        public Uri CreateWunUri(WunDataFeatures dataFeatures, string location)
        {
            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format($"{wunApiKey}/pws/{dataFeatures}/q/pws:{location}.json"));
            // Complete uri will look something like: http://api.wunderground.com/api/YourApiKey/pws/conditions/q/pws:ISOUTHLA34.json
        }
    }
}
