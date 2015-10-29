using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WundergroundNetLib;

namespace WundergroundNetTest
{
    [TestClass]
    public class UriProviderTest
    {
        [TestMethod]
        public void GivenStringCoordinates_ReturnWellFormedUri_WhenCallingCreateUriForAstroCondForecastFromCoordinates()
        {
            UriProvider provider = new UriProvider();
            Uri actualUri = provider.CreateUriFromCoordinatesForAstroCondForecast("-43.537358,172.640151");
            bool isWellFormedUri = Uri.IsWellFormedUriString(actualUri.ToString(), UriKind.Absolute);
            Assert.IsTrue(isWellFormedUri);
        }
    }
}
