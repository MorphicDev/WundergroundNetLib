using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Plugin
{
    /// <summary>
    /// The weather operation is not supported by the current service
    /// </summary>
    public class WeatherServiceOperationNotSupportedException : NotSupportedException
    {
        private const String DefaultExceptionMessage = @"Weather Service operation is not supported. The remote API may not offer the functionality or the service is in an incorrect state for this operation.";
        
        /// <summary>
        /// Instantiate a new instance of WundergroundNetLib.Interfaces.Plugin.WeatherServiceOperationNotSupportedException with appropriate default values
        /// </summary>
        /// <param name="message">Message describing the failure</param>
        /// <param name="innerException">An exception that was caught and caused this exception to be thrown</param>
        public WeatherServiceOperationNotSupportedException(String message = DefaultExceptionMessage, Exception innerException = null) : base(message, innerException)
        {

        }
        
    }
}
