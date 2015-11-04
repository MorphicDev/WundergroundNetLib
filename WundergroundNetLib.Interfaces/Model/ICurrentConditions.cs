using System;

namespace WundergroundNetLib.Interfaces
{
    public interface ICurrentConditions
    {
        string CurrentDescription { get; set; }
        DateTime ObservationTime { get; set; }
        double PrecipLastHr { get; set; }
        double PrecipToday { get; set; }
        int PressureMb { get; set; }
        string RelativeHumidity { get; set; }
        string Sunrise { get; set; }
        string Sunset { get; set; }
        double TempCelsius { get; set; }
        double UVIndex { get; set; }
        double VisibilityKm { get; set; }
        string WeatherIcon { get; set; }
        string WeatherIconUrl { get; set; }
        double WindAvgKph { get; set; }
        int WindDegrees { get; set; }
        string WindDescription { get; set; }
        string WindDirection { get; set; }
        double WindGustKph { get; set; }
    }
}