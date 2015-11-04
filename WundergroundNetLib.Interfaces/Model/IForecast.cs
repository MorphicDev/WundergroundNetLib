using System;

namespace WundergroundNetLib.Interfaces
{
    public interface IForecast
    {
        DateTime Date { get; set; }
        string Day { get; set; }
        string DetailedDescriptionDay { get; set; }
        string DetailedDescriptionNight { get; set; }
        double HighCelcius { get; set; }
        double LowCelcius { get; set; }
        string RelativeHumidity { get; set; }
        string SimpleDescription { get; set; }
        string WeatherIcon { get; set; }
        string WeatherIconUrl { get; set; }
        double WindAvgKph { get; set; }
        string WindDirection { get; set; }
        double WindGustKph { get; set; }
    }
}