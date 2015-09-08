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

    public static class DataProvider
    {
        public static T GetData<T>(PwsGeographicLocation location, WunDataFeatures dataFeatures)
        {
            string pwsIdentifier = GetPwsIdentifier(location);
            Uri pwsUri = UriProvider.CreateWunUri(dataFeatures, pwsIdentifier);
            string jsonData = JsonProvider.DownloadJsonString(pwsUri);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        public static string GetPwsIdentifier(PwsGeographicLocation location)
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
