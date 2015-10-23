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
            string jsonData = jsonProvider.DownloadJsonString(pwsUri);
            return JsonConvert.DeserializeObject<T>(jsonData);
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
