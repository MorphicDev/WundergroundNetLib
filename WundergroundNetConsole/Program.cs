using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundergroundNetLib.Model;
using WundergroundNetLib.Interfaces;

namespace WundergroundNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            IWundergroundDataProvider dataProvider = WundergroundDataProvider.DefaultProvider; // ensure only one instance is created using the WundergroundDataProvider singleton

            //var WundergroundData = dataProvider.GetWundergroundWeatherDataAsync("-43.506923", "172.731346");
            //var WundergroundData = dataProvider.GetWundergroundWeatherDataAsync("ICANTERB275");
            var WeatherData = dataProvider.GetWundergroundWeatherDataAsync(-43.506923, 172.731346);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Observation Location Details");
            Console.WriteLine();
            
            Console.WriteLine("City \t\t\t{0}", WeatherData.Result.observationLocation.City);
            Console.WriteLine("Country \t\t{0}", WeatherData.Result.observationLocation.Country);
            Console.WriteLine("StationLatitude \t{0}", WeatherData.Result.observationLocation.StationLatitude);
            Console.WriteLine("StationLongitude \t{0}", WeatherData.Result.observationLocation.StationLongitude);
            Console.WriteLine("StationElevation \t{0}", WeatherData.Result.observationLocation.StationElevation);
            Console.WriteLine("StationID \t\t{0}", WeatherData.Result.observationLocation.StationID);
            Console.WriteLine("WmoNumber \t\t{0}", WeatherData.Result.observationLocation.WmoNumber);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Current Conditions");
            Console.WriteLine();

            Console.WriteLine("ObservationTime \t\t{0}", WeatherData.Result.currentConditions.ObservationTime);
            Console.WriteLine("CurrentDescription \t\t{0}", WeatherData.Result.currentConditions.CurrentDescription);
            Console.WriteLine("TempCelsius \t\t\t{0}", WeatherData.Result.currentConditions.TempCelsius);
            Console.WriteLine("RelativeHumidity \t\t{0}", WeatherData.Result.currentConditions.RelativeHumidity);
            Console.WriteLine("WindDescription \t\t{0}", WeatherData.Result.currentConditions.WindDescription);
            Console.WriteLine("WindDirection \t\t\t{0}", WeatherData.Result.currentConditions.WindDirection);
            Console.WriteLine("WindDegrees \t\t\t{0}", WeatherData.Result.currentConditions.WindDegrees);
            Console.WriteLine("WindAvgKph \t\t\t{0}", WeatherData.Result.currentConditions.WindAvgKph);
            Console.WriteLine("WindGustKph \t\t\t{0}", WeatherData.Result.currentConditions.WindGustKph);
            Console.WriteLine("PressureMb \t\t\t{0}", WeatherData.Result.currentConditions.PressureMb);
            Console.WriteLine("UVIndex \t\t\t{0}", WeatherData.Result.currentConditions.UVIndex);
            Console.WriteLine("VisibilityKm \t\t\t{0}", WeatherData.Result.currentConditions.VisibilityKm);
            Console.WriteLine("PrecipLastHr \t\t\t{0}", WeatherData.Result.currentConditions.PrecipLastHr);
            Console.WriteLine("PrecipToday \t\t\t{0}", WeatherData.Result.currentConditions.PrecipToday);
            Console.WriteLine("WeatherIcon \t\t\t{0}", WeatherData.Result.currentConditions.WeatherIcon);
            Console.WriteLine("WeatherIconUrl \t\t\t{0}", WeatherData.Result.currentConditions.WeatherIconUrl);
            Console.WriteLine("Sunrise \t\t\t{0}", WeatherData.Result.currentConditions.Sunrise);
            Console.WriteLine("Sunset \t\t\t\t{0}", WeatherData.Result.currentConditions.Sunset);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Four Day Forecast");
            Console.WriteLine();

            foreach (var item in WeatherData.Result.fourDayForecast)
            {
                Console.WriteLine("Day \t\t\t\t{0}", item.Day);
                Console.WriteLine("------------------------------------");
                Console.WriteLine("Date \t\t\t\t{0}", item.Date);
                Console.WriteLine("SimpleDescription \t\t{0}", item.SimpleDescription);
                Console.WriteLine("DetailedDescriptionDay \t\t{0}", item.DetailedDescriptionDay);
                Console.WriteLine("DetailedDescriptionNight \t{0}", item.DetailedDescriptionNight);
                Console.WriteLine("HighCelcius \t\t\t{0}", item.HighCelcius);
                Console.WriteLine("LowCelcius \t\t\t{0}", item.LowCelcius);
                Console.WriteLine("RelativeHumidity \t\t{0}", item.RelativeHumidity);
                Console.WriteLine("WindAvgKph \t\t\t{0}", item.WindAvgKph);
                Console.WriteLine("WindGustKph \t\t\t{0}", item.WindGustKph);
                Console.WriteLine("WindDirection \t\t\t{0}", item.WindDirection);
                Console.WriteLine("WeatherIcon \t\t\t{0}", item.WeatherIcon);
                Console.WriteLine("WeatherIconUrl \t\t\t{0}", item.WeatherIconUrl);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
