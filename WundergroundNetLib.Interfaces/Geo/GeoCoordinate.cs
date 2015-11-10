using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Geo
{
    /// <summary>
    /// GeoCoordinate. Use static methods to create an instance
    /// </summary>
    public class GeoCoordinate
    {
        #region Static generators

        /// <summary>
        /// Create a GeoCoordinate instance timestamped to DateTime.Now
        /// </summary>
        /// <param name="longitude">Longitude in degrees</param>
        /// <param name="latitude">Latitude in degrees</param>
        /// <param name="accuracy">Accuracy in meters</param>
        /// <param name="altitude">Altitude in meters above sea-level</param>
        /// <param name="altitudeAccuracy">Altitude accuracy in meters</param>
        /// <param name="heading">Heading in degrees clockwise from north</param>
        /// <param name="speed">Speed in meters per second</param>
        /// <returns>GeoCoordinate</returns>
        public static GeoCoordinate CreateNow(double longitude, double latitude, double accuracy, double? altitude = null, double? altitudeAccuracy = null, double? heading = null, double? speed = null)
        {
            return CreateFromDateTime(longitude, latitude, accuracy, DateTime.Now, altitude, altitudeAccuracy, heading, speed);
        }

        /// <summary>
        /// Create a GeoCoordinate instance timestamped to DateTime.Now
        /// </summary>
        /// <param name="longitude">Longitude in degrees</param>
        /// <param name="latitude">Latitude in degrees</param>
        /// <param name="accuracy">Accuracy in meters</param>
        /// <param name="when">Timestamp of geo information</param>
        /// <param name="altitude">Altitude in meters above sea-level</param>
        /// <param name="altitudeAccuracy">Altitude accuracy in meters</param>
        /// <param name="heading">Heading in degrees clockwise from north</param>
        /// <param name="speed">Speed in meters per second</param>
        /// <returns>GeoCoordinate</returns>
        public static GeoCoordinate CreateFromDateTime(double longitude, double latitude, double accuracy, DateTime when, double? altitude = null, double? altitudeAccuracy = null, double? heading = null, double? speed = null)
        {
            return new GeoCoordinate()
            {
                Longitude = longitude,
                Latitude = latitude,
                Accuracy = accuracy,
                Timestamp = when,
                Altitude = altitude,
                AltitudeAccuracy = altitudeAccuracy,
                Heading = heading,
                Speed = speed
            };
        }
        #endregion

        #region Required Properties
        /// <summary>
        /// Latitude & Longitude accuracy in meters
        /// </summary>
        public double Accuracy { get; internal set; }
        /// <summary>
        /// Latitude in degrees, valid range: -90.0 to 90.0
        /// </summary>
        public double Latitude { get; internal set; }
        /// <summary>
        /// Longitude in degrees, valid range: -180.0 to 180.0
        /// </summary>
        public double Longitude { get; internal set; }
        /// <summary>
        /// Timestamp of when the GeoCoordinate was sampled.
        /// </summary>
        public DateTime Timestamp { get; internal set; }
        #endregion

        #region Optional Properties
        /// <summary>
        /// Altitude in meters above sea-level
        /// </summary>
        public Nullable<double> Altitude { get; internal set; }
        /// <summary>
        /// Altitude accuracy in meters
        /// </summary>
        public Nullable<double> AltitudeAccuracy { get; internal set; }
        /// <summary>
        /// Heading direction in degrees, clockwise from North
        /// </summary>
        public Nullable<double> Heading { get; internal set; }
        /// <summary>
        /// Speed in meters/second
        /// </summary>
        public Nullable<double> Speed { get; internal set; }
        #endregion
    }
}
