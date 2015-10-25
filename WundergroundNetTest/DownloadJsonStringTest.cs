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
            bool expectedResultValue = true;
            UriProvider uriProvider = new UriProvider();
            Uri testUri = uriProvider.CreateWunUri(WunDataFeatures.astronomy, "INORTHLA43");
            JsonProvider jsonProvider = new JsonProvider();

            //Act
            string jsonData = jsonProvider.DownloadJsonString(testUri);
            if (string.IsNullOrEmpty(jsonData) == true)
            {
                actualResultValue = false;
                Console.WriteLine("True");
            }
            else
            {
                actualResultValue = true;
                Console.WriteLine("false");
            }

            //Assert
            Assert.AreEqual(expectedResultValue, actualResultValue);
        }

        [TestMethod]
        public void GivenValidUri_WhenCallingDownloadJsonStringAsync_ThenStringFileReturned()
        {
            // Arrange
            bool actualResultValue = false;
            bool expectedResultValue = true;
            UriProvider uriProvider = new UriProvider();
            Uri testUri = uriProvider.CreateWunUri(WunDataFeatures.astronomy, "INORTHLA43");
            JsonProvider jsonProvider = new JsonProvider();

            //Act
            string jsonData = jsonProvider.DownloadJsonString(testUri);
            if (string.IsNullOrEmpty(jsonData) == true)
            {
                actualResultValue = false;
                Console.WriteLine("True");
            }
            else
            {
                actualResultValue = true;
                Console.WriteLine("false");
            }

            //Assert
            Assert.AreEqual(expectedResultValue, actualResultValue);
        }
    }
}
