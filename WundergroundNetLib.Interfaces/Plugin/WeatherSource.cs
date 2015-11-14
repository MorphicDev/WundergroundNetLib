using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// A weather source that can generate a <see cref="WeatherSample"/>
    /// </summary>
    public class WeatherSource
    {
        /// <summary>
        /// Instantiate a new WeatherSource
        /// </summary>
        /// <param name="name">Name of the weather source. Must not be null or empty</param>
        /// <param name="location">Location of weather source. Must not be null</param>
        public WeatherSource(String name, Geo.GeoCoordinate location)
        {
            if(null == location)
            {
                throw new ArgumentNullException("location", "GeoCoordinate location parameter must not be null");
            }

            if(String.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name", "Weather source cannot be null or empty.");
            }

            Name = name;
            Location = location;
        }
        
        /// <summary>
        /// Location of this weather source
        /// </summary>
        public Geo.GeoCoordinate Location { get; private set; }

        /// <summary>
        /// Name of this weather source
        /// </summary>
        public String Name { get; private set; }
    }
}
