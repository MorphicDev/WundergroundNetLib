using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WundergroundNetLib.Model;

namespace WundergroundNetTest
{
    [TestClass]
    public class UriProviderTest
    {
        [TestMethod]
        public void GivenStringCoordinates_ReturnWellFormedUri_WhenCallingCreateUriForAstroCondForecastFromCoordinates()
        {
            UriProvider provider = new UriProvider();
            Uri actualUri = provider.CreateCombinedDataUriFromCoordinates("-43.506923", "172.731346");
            bool isWellFormedUri = Uri.IsWellFormedUriString(actualUri.ToString(), UriKind.Absolute);
            Assert.IsTrue(isWellFormedUri);
        }
    }
}
