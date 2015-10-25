using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace WundergroundNetLib
{
    public enum PwsGeographicLocation
    {
        // Town_Region_Country
        Oban_StewartIsland_NZ,
        Kaitaia_Northland_NZ
    }

    public class DataProvider
    {
        public T GetData<T>(PwsGeographicLocation location, WunDataFeatures dataFeatures) where T : IWunData
        {
            UriProvider uriProvider = new UriProvider();
            string pwsIdentifier = GetPwsIdentifier(location);
            Uri pwsUri = uriProvider.CreateWunUri(dataFeatures, pwsIdentifier);
            JsonProvider jsonProvider = new JsonProvider();
            Console.WriteLine("This will test whether I've done async right");
            //#Legacy Code#
            #region Old Code
            string jsonData = jsonProvider.DownloadJsonString(pwsUri);
            Console.WriteLine("GETDATA: If this goes first then I'm doing this wrong");
            return JsonConvert.DeserializeObject<T>(jsonData);
            #endregion

            //New Code that calls Asynchornious method for downloading JSON file
            //Task<string> jsonData = jsonProvider.DownloadJsonStringAsync(pwsUri);
            //Console.WriteLine("GETDATA: If this goes first then I'm doing this right");
            //return JsonConvert.DeserializeObject<T>(jsonData.Result);


        }

        public string GetPwsIdentifier(PwsGeographicLocation location)
        {
            string pwsIdentifier = "";
            switch (location)
            {
                case PwsGeographicLocation.Oban_StewartIsland_NZ:
                    pwsIdentifier = "ISOUTHLA34";
                    break;
                case PwsGeographicLocation.Kaitaia_Northland_NZ:
                    pwsIdentifier = "INORTHLA43";
                    break;
            }
            return pwsIdentifier;
        }
    }
}
