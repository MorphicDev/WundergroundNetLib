using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib
{
    public class WeatherData : IWunData
    {
        public ObservationLocation observationLocation { get; set; }
        public CurrentConditions currentConditions { get; set; }
        public List<Forecast> fourDayForecast = new List<Forecast>();
    }

    public class ObservationLocation
    {
        public string City { get; set; } // city : "Christchurch" / display_location
        public string Country { get; set; } // country_iso3166 : "NZ" / observation_location
        public double StationLatitude { get; set; } // latitude : "-43.530000" / observation_location
        public double StationLongitude { get; set; } // longitude : "172.640000" / observation_location
        public string StationElevation { get; set; } // elevation : "197 ft" / observation_location
        public string StationID { get; set; } // station_id : "ICANTERB108" (From current_observation)
        public int WmoNumber { get; set; } // wmo : "93780" / display_location
    }

    public class CurrentConditions
    {
        public DateTime ObservationTime { get; set; } // observation_time_rfc822 : "Fri, 30 Oct 2015 07:56:47 +1300"
        public string CurrentDescription { get; set; } // weather : "Rain"
        public double TempCelsius { get; set; } // temp_c : 4.9 - convert to double
        public string RelativeHumidity { get; set; } // relative_humidity : "86%"
        public string WindDescription { get; set; } // wind_string : "From the WSW at 1.0 MPH Gusting to 2.0 MPH"
        public string WindDirection { get; set; } // wind_dir : "WSW" ---> Could change this to enum
        public int WindDegrees { get; set; } // wind_degrees : 247
        public double WindAvgKph { get; set; } // wind_kph : 1.6
        public double WindGustKph { get; set; } // wind_gust_kph : "3.2" - this will need to be converted to double
        public int PressureMb { get; set; } // pressure_mb : "1005" - Convert to int?
        public double UVIndex { get; set; } // UV : "0" - convert to int or double?
        public double VisibilityKm { get; set; } // visibility_km : "10.0"
        public double PrecipLastHr { get; set; } // precip_1hr_metric : " 1"
        public double PrecipToday { get; set; } // precip_today_metric : "1"
        public string WeatherIcon { get; set; } // icon : "rain"
        public string WeatherIconUrl { get; set; } // icon_url : "http://icons.wxug.com/i/c/k/rain.gif"
        public string Sunrise { get; set; } // sun_phase / sunrise / hour : "6" / minute : "18"
        public string Sunset { get; set; } // sun_phase / sunset etc
    }

    public class Forecast
    {
        public string Day { get; set; }  // simpleforecast / forecastday / date / weekday_short
        public DateTime Date { get; set; } // simpleforecast / forecastday / date / year, month, day
        public string SimpleDescription { get; set; } // simpleforecast / forecastday / conditions : "Chance of Rain"
        public string DetailedDescriptionDay { get; set; } // txt_forecast / Even Number / "Cloudy this morning with showers during the afternoon. High 17C. Winds S at 15 to 30 km/h. Chance of rain 40%." 
        public string DetailedDescriptionNight { get; set; } // txt_forecast / Odd Number / "Partly cloudy skies. Low 11C. Winds SE at 10 to 15 km/h."
        public double HighCelcius { get; set; } // simpleforecast / forecastday / high / celsius
        public double LowCelcius { get; set; } // simpleforecast / forecastday / low / celsius
        public string RelativeHumidity { get; set; }
        public double WindAvgKph { get; set; } // simpleforecast / forecastday / avewind / kph : 32
        public double WindGustKph { get; set; } // simpleforecast / forecastday / maxwind / kph : 32
        public string WindDirection { get; set; } // simpleforecast / forecastday / avewind / dir : "S"
        public string WeatherIcon { get; set; } // simpleforecast / forecastday / icon : "chancerain"
        public string WeatherIconUrl { get; set; } // simpleforecast / forecastday / icon_url : "http://icons.wxug.com/i/c/k/chancerain.gif"
    }
}