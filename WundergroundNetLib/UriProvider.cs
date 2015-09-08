using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using WundergroundNetLib.Properties;

namespace WundergroundNetLib
{
    public static class UriProvider
    {
        public static Uri CreateWunUri(WunDataFeatures dataFeatures, string location)
        {
            // You will need to create your own Wunderground API key. 
            // Learn more: http://www.wunderground.com/weather/api/d/docs 
            // Add that key to a file called WundergroundApiKey.txt
            // The line below references the internal resource for that key

            string wunApiKey = Resources.WundergroundApiKey;
            Uri baseUri = new Uri("http://api.wunderground.com/api/");
            return new Uri(baseUri, string.Format("{0}/pws/{1}/q/pws:{2}.json", wunApiKey, dataFeatures, location));

            // Complete uri will look something like: http://api.wunderground.com/api/YourApiKey/pws/conditions/q/pws:ISOUTHLA34.json
        }
    }
}
