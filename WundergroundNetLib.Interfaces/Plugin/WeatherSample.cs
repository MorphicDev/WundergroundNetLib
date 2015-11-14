using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// Captured weather sample containing location and weather data
    /// </summary>
    public class WeatherSample
    {
        /// <summary>
        /// Source that generated this sample
        /// </summary>
        public WeatherSource Source { get; internal set; }

        /// <summary>
        /// Weather sample timestamp. Should be accurate to when the data was recorded so that it may be used for predictions
        /// </summary>
        public DateTime Timestamp { get; internal set; }
    }
}
