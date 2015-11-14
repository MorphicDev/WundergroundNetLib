using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// Weather Service acts as a gateway to an external weather source such as a web api
    /// </summary>
    public interface IWeatherService
    {
        #region Synchronous operations
        /// <summary>
        /// Get a weather sample near a location
        /// </summary>
        /// <param name="coordinate">Location to get a weather sample for</param>
        /// <returns>A weather sample</returns>
        WeatherSample FetchForLocation(Geo.GeoCoordinate coordinate);

        /// <summary>
        /// Get a weather sample from a specified source (such as a personal weather station or aggregated civilian location)
        /// </summary>
        /// <param name="source">The source to request a weather sample from</param>
        /// <returns>A weather sample</returns>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support fetching samples from a weather source</exception>
        WeatherSample FetchFromWeatherSource(WeatherSource source);

        /// <summary>
        /// Get an enumerable of weather sources. Optionally filtered by location and max number
        /// </summary>
        /// <param name="coordinate">Coordinate to filter by</param>
        /// <param name="maxSources">The max amount of sources to fetch. Less may be returned</param>
        /// <returns>Enumerable of Weather Sources</returns>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support listing sources</exception>
        IEnumerable<WeatherSource> GetSources(Geo.GeoCoordinate coordinate = null, int? maxSources = null);
        #endregion

        #region Async operations
        /// <summary>
        /// Get a weather sample near a location
        /// </summary>
        /// <param name="coordinate">Location to get a weather sample for</param>
        /// <returns>A weather sample</returns>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support asyncronous operations</exception>
        Task<WeatherSample> FetchForLocationAsync(Geo.GeoCoordinate coordinate);

        /// <summary>
        /// Get a weather sample from a specified source (such as a personal weather station or aggregated civilian location)
        /// </summary>
        /// <param name="source">The source to request a weather sample from</param>
        /// <returns>A weather sample</returns>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support fetching samples from a weather source</exception>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support asyncronous operations</exception>
        Task<WeatherSample> FetchFromWeatherSourceAsync(WeatherSource source);

        // Look at System.IObservable<T>. It provides a pub/sub model. It's an option
        /// <summary>
        /// Get an enumerable of weather sources. Optionally filtered by location and max number
        /// </summary>
        /// <param name="coordinate">Coordinate to filter by</param>
        /// <param name="maxSources">The max amount of sources to fetch. Less may be returned</param>
        /// <returns>Enumerable of Weather Sources</returns>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support listing sources</exception>
        /// <exception cref="WeatherServiceOperationNotSupportedException">Thrown if this service does not support asyncronous operations</exception>
        Task<IEnumerable<WeatherSource>> GetSourcesAsync(Geo.GeoCoordinate coordinate = null, int? maxSources = null);
        #endregion
    }
}
