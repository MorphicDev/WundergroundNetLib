using System;
using System.Threading.Tasks;
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
        /// <summary>
        /// Generic method for getting the data features of your choosing as a synchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="dataFeatures"></param>
        /// <returns></returns>
        public T GetData<T>(PwsGeographicLocation location, WunDataFeatures dataFeatures) where T : IWunData
        {
            UriProvider uriProvider = new UriProvider();
            string pwsIdentifier = GetPwsIdentifier(location);
            Uri pwsUri = uriProvider.CreateWunUri(dataFeatures, pwsIdentifier);
            JsonProvider jsonProvider = new JsonProvider();
            string jsonData = jsonProvider.DownloadJsonString(pwsUri);
            return JsonConvert.DeserializeObject<T>(jsonData);
        }

        /// <summary>
        /// Generic method for getting the data features of your choosing as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="dataFeatures"></param>
        /// <returns></returns>
        public async Task<T> GetDataAsync<T>(PwsGeographicLocation location, WunDataFeatures dataFeatures) where T : IWunData
        {
            UriProvider uriProvider = new UriProvider();
            string pwsIdentifier = GetPwsIdentifier(location);
            Uri pwsUri = uriProvider.CreateWunUri(dataFeatures, pwsIdentifier);
            JsonProvider jsonProvider = new JsonProvider();
            string jsonData = await jsonProvider.DownloadJsonStringAsync(pwsUri);
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
