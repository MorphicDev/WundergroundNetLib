using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IWeatherIcon
    {
        string WeatherIcon { get; set; }
        string WeatherIconUrl { get; set; }
    }
}
