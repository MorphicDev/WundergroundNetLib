using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// A weather service provider faciliates the instantiation of a weather service object
    /// </summary>
    public interface IWeatherServiceProvider
    {
        /// <summary>
        /// Create an instance of a Weather Service.
        /// </summary>
        /// <param name="instantiationData">Optional instantiation data that the service may require. e.g. An API Key</param>
        /// <returns>An instance of IWeatherService</returns>
        /// <exception cref="WeatherServiceProviderException">May be thrown if creation of the service fails</exception>
        IWeatherService CreateWeatherServiceInstance(String instantiationData = null);

        /// <summary>
        /// Description or help information for this service provider
        /// </summary>
        String Information { get; }

        /// <summary>
        /// Name of the weather service. This may be the name of the backend api in use or another name.
        /// </summary>
        String ServiceName { get; }
    }
}
