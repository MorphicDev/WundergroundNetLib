using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundergroundNetLib;

namespace WundergroundNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DataProvider dataProvider = new DataProvider();
            var KaitaiaAstroData = dataProvider.GetData<WunAstronomy>(PwsGeographicLocation.Kaitaia_Northland_NZ, WunDataFeatures.astronomy);
            Console.WriteLine("Sunrise in Kaitaia is: {0}:{1}", KaitaiaAstroData.sun_phase.sunrise.hour, KaitaiaAstroData.sun_phase.sunrise.minute);
            Console.ReadKey();
        }
    }
}
