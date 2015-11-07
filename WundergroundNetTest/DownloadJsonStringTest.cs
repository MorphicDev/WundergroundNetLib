using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WundergroundNetLib.Model;
using System.Threading.Tasks;

namespace WundergroundNetTest
{
    [TestClass]
    public class DownloadJsonStringTest
    {

        //[TestMethod]
        //public void GivenValidUri_WhenCallingDownloadJsonString_ThenStringFileReturned()
        //{
        //    // Arrange
        //    bool actualResultValue = false;
        //    UriProvider uriProvider = new UriProvider();
        //    Uri testUri = uriProvider.CreateCombinedDataUriFromPwsStationID("INORTHLA43");
        //    JsonProvider jsonProvider = new JsonProvider();

        //    //Act
        //    string jsonData = jsonProvider.DownloadJsonString(testUri);
        //    if (string.IsNullOrEmpty(jsonData) == true)
        //    {
        //        actualResultValue = false;
        //    }
        //    else
        //    {
        //        actualResultValue = true;
        //    }

        //    //Assert
        //    Assert.IsTrue(actualResultValue);
        //}

        [TestMethod]
        public void GivenValidUri_WhenCallingDownloadJsonStringAsync_ThenStringFileReturned()
        {
            // Arrange
            bool actualResultValue = false;
            UriProvider uriProvider = new UriProvider();
            Uri testUri = uriProvider.CreateCombinedDataUriFromPwsStationID("INORTHLA43");
            JsonProvider jsonProvider = new JsonProvider();

            //Act
            Task<string> jsonData = jsonProvider.DownloadJsonStringAsync(testUri);
            if (string.IsNullOrEmpty(jsonData.Result) == true)
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
