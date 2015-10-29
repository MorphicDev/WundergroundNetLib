﻿using System;
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
            Uri pwsUri = uriProvider.CreateUriFromPwsLocationForSpecificFeature(dataFeatures, pwsIdentifier);
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
            Uri pwsUri = uriProvider.CreateUriFromPwsLocationForSpecificFeature(dataFeatures, pwsIdentifier);
            JsonProvider jsonProvider = new JsonProvider();
            string jsonData = await jsonProvider.DownloadJsonStringAsync(pwsUri);
            return await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(jsonData));
        }

        /// <summary>
        /// Get the combined json file including conditions, forecast and astronomy data and deserialise into 
        /// customised weather data classes using your coordinates, executed as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="dataFeatures"></param>
        /// <returns></returns>
        public async Task<T> GetCombinedDataAsync<T>(string coordinates) where T : IWunData
        {
            // Set Uri
            UriProvider uriProvider = new UriProvider();
            Uri pwsUri = uriProvider.CreateCombinedDataUriFromCoordinates(coordinates);
            // Download Json data
            JsonProvider jsonProvider = new JsonProvider();
            string jsonData = await jsonProvider.DownloadJsonStringAsync(pwsUri);
            // Deserialise Json file into custom object

            // Create Custom Object - Look through JSON file and work out what data we need
            // http://api.wunderground.com/api/046205dccf61046c/conditions/forecast/astronomy/q/-43.537358,172.640151.json
            // http://jsonviewer.stack.hu/#http://api.wunderground.com/api/046205dccf61046c/conditions/forecast/astronomy/q/-43.537358,172.640151.json
            // http://jsonviewer.stack.hu/#http://api.wunderground.com/api/046205dccf61046c/conditions/forecast/astronomy/q/CA/San_Francisco.json
            // Create method that uses LINQ to Json to deserialise json
            // http://www.newtonsoft.com/json/help/html/QueryingLINQtoJSON.htm
            // http://www.newtonsoft.com/json/help/html/SerializingJSONFragments.htm

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
