using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// Exception that may be thrown by IWeatherServiceProvider
    /// </summary>
    public class WeatherServiceProviderException : Exception
    {
        /// <summary>
        /// Create a Weather Service Provider Exception
        /// </summary>
        /// <param name="reason">Not-Optional reason for the failure</param>
        public WeatherServiceProviderException(String reason) : base(reason)
        {

        }

        /// <summary>
        /// Create a Weather Service Provider Exception
        /// </summary>
        /// <param name="reason">Non-Optional reason for the failure</param>
        /// <param name="innerException">The exception that caused this one</param>
        public WeatherServiceProviderException(String reason, Exception innerException) : base(reason, innerException)
        {

        }

        /// <summary>
        /// Extra data attached to this exception
        /// </summary>
        public Object Tag { get; set; }
    }
}
