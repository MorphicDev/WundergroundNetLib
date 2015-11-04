using System;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace WundergroundNetLib
{
    public class WundergroundDataProvider : IWundergroundDataProvider
    {
        /// <summary>
        /// Get the combined json file including conditions, forecast and astronomy data and deserialise into 
        /// customised weather data classes using your string coordinates, executed as an asynchronous operation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="location"></param>
        /// <param name="dataFeatures"></param>
        /// <returns></returns>
        public async Task<IWundergroundData> GetWundergroundWeatherDataAsync(string latitude, string longitude)
        {
            IUriProvider uriProvider = new UriProvider();
            Uri pwsUri = uriProvider.CreateCombinedDataUriFromCoordinates(latitude, longitude);
            return await CombinedWeatherDataAsync(pwsUri);
        }

        /// <summary>
        /// Get the combined json file including conditions, forecast and astronomy data and deserialise into 
        /// customised weather data classes using your double coordinates, executed as an asynchronous operation.
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public async Task<IWundergroundData> GetWundergroundWeatherDataAsync(double latitude, double longitude)
        {
            IUriProvider uriProvider = new UriProvider();
            Uri pwsUri = uriProvider.CreateCombinedDataUriFromCoordinates(latitude, longitude);
            return await CombinedWeatherDataAsync(pwsUri);
        }

        /// <summary>
        /// Get the combined json file including conditions, forecast and astronomy data and deserialise into 
        /// customised weather data classes using a specific pws station id ("ICANTERB275"), executed as an asynchronous operation.
        /// </summary>
        /// <param name="stationID"></param>
        /// <returns></returns>
        public async Task<IWundergroundData> GetWundergroundWeatherDataAsync(string stationID)
        {
            IUriProvider uriProvider = new UriProvider();
            Uri pwsUri = uriProvider.CreateCombinedDataUriFromPwsStationID(stationID);
            return await CombinedWeatherDataAsync(pwsUri);
        }

        /// <summary>
        /// Receives a uri and uses this to download a json file and deserialise it into the custom WundergroundData object as an async operation.
        /// </summary>
        /// <param name="pwsUri"></param>
        /// <returns></returns>
        private async Task<IWundergroundData> CombinedWeatherDataAsync(Uri pwsUri)
        {
            // Download Json data
            JsonProvider jsonProvider = new JsonProvider();
            string jsonData = await jsonProvider.DownloadJsonStringAsync(pwsUri);

            // Deserialise Json file into custom object
            JsonDeserializer jsonDeserialize = new JsonDeserializer();
            return await jsonDeserialize.JsonToWeatherDataAsync(jsonData);
        }
    }
}
