using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WundergroundNetLib;

namespace WundergroundNetTest
{
    [TestClass]
    public class DownloadJsonStringTest
    {
        [TestMethod]
        public void GivenValidUri_WhenCallingDownloadJsonString_ThenStringFileReturned()
        {
            // Arrange
            bool actualResultValue = false;
            Uri testUri = new Uri("http://api.wunderground.com/api/eaeb092839bd9885/pws/astronomy/q/pws:INORTHLA43.json");
            JsonProvider jsonProvider = new JsonProvider();

            //Act
            string jsonData = jsonProvider.DownloadJsonString(testUri);
            if (string.IsNullOrEmpty(jsonData) == true)
            {
                actualResultValue = false;
            }
            else
            {
                actualResultValue = true;
            }
            
            //Assert
            Assert.IsTrue(actualResultValue);

        }
        [TestMethod]
        public void GivenValidUri_WhenCallingDownloadJsonStringAsync_ThenStringFileReturned()
        {
            // Arrange
            bool actualResultValue = false;
            Uri testUri = new Uri("http://api.wunderground.com/api/eaeb092839bd9885/pws/astronomy/q/pws:INORTHLA43.json");
            JsonProvider jsonProvider = new JsonProvider();

            //Act
            string jsonData = jsonProvider.DownloadJsonString(testUri);
            if (string.IsNullOrEmpty(jsonData) == true)
            {
                actualResultValue = false;
            }
            else
            {
                actualResultValue = true;
            }

            //Assert
            Assert.IsTrue(actualResultValue);
        }
    }
}
