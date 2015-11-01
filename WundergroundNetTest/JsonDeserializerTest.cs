using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WundergroundNetLib;

namespace WundergroundNetTest
{
    [TestClass]
    public class JsonDeserializerTest
    {
        [TestMethod]
        public void JsonToWeatherDataPrototypeTest()
        {
            // Arrange
            var uriProvider = new UriProvider();
            Uri actualUri = uriProvider.CreateCombinedDataUriFromCoordinates("-43.506923,172.731346");
            var jsonProvider = new JsonProvider();
            string jsonData = jsonProvider.DownloadJsonString(actualUri);
            var jsonDeserializer = new JsonDeserializer();

            // Act
            var weatherData = jsonDeserializer.JsonToWeatherDataAsync(jsonData);

            string obsCity = weatherData.Result.observationLocation.City;
            // Assert
            Assert.IsNotNull(obsCity);
        }
    }
}