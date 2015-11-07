using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WundergroundNetLib.Model;
using WundergroundNetLib.Interfaces.Data;

namespace WundergroundNetConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WundergroundDataProvider dataProvider = WundergroundDataProvider.DefaultProvider; // ensure only one instance is created using the WundergroundDataProvider singleton

            //var WundergroundData = dataProvider.GetWundergroundWeatherDataAsync("-43.506923", "172.731346");
            //var WundergroundData = dataProvider.GetWundergroundWeatherDataAsync("ICANTERB275");
            var weatherData = dataProvider.GetWundergroundWeatherDataAsync(-43.506923, 172.731346);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Test Casting to Implemented Interfaces");

            IWundergroundWeatherData entireData = weatherData.Result;
            var stationId = entireData.ObservationLocationInfo as IWundergroundStationID;
            if (stationId != null)
            {
                Console.WriteLine("Station ID: {0}", stationId.StationID);
            }

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Observation Location Details");
            Console.WriteLine();
            
            Console.WriteLine("City \t\t\t{0}", weatherData.Result.ObservationLocationInfo.City);
            Console.WriteLine("Country \t\t{0}", weatherData.Result.ObservationLocationInfo.Country);
            Console.WriteLine("StationLatitude \t{0}", weatherData.Result.ObservationLocationInfo.StationLatitude);
            Console.WriteLine("StationLongitude \t{0}", weatherData.Result.ObservationLocationInfo.StationLongitude);
            Console.WriteLine("StationID \t\t{0}", weatherData.Result.ObservationLocationInfo.StationID);
            Console.WriteLine("WmoNumber \t\t{0}", weatherData.Result.ObservationLocationInfo.WmoNumber);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Current Conditions");
            Console.WriteLine();

            Console.WriteLine("ObservationTime \t\t{0}", weatherData.Result.CurrentConditions.ObservationTime);
            Console.WriteLine("TempCelsius \t\t\t{0}", weatherData.Result.CurrentConditions.TempCelsius);
            Console.WriteLine("RelativeHumidity \t\t{0}", weatherData.Result.CurrentConditions.RelativeHumidity);
            Console.WriteLine("WindDirection \t\t\t{0}", weatherData.Result.CurrentConditions.WindDirection);
            Console.WriteLine("WindDegrees \t\t\t{0}", weatherData.Result.CurrentConditions.WindDegrees);
            Console.WriteLine("WindAvgKph \t\t\t{0}", weatherData.Result.CurrentConditions.WindAvgKph);
            Console.WriteLine("WindGustKph \t\t\t{0}", weatherData.Result.CurrentConditions.WindGustKph);
            Console.WriteLine("PressureMb \t\t\t{0}", weatherData.Result.CurrentConditions.PressureMb);
            Console.WriteLine("UVIndex \t\t\t{0}", weatherData.Result.CurrentConditions.UVIndex);
            Console.WriteLine("VisibilityKm \t\t\t{0}", weatherData.Result.CurrentConditions.VisibilityKm);
            Console.WriteLine("PrecipLastHr \t\t\t{0}", weatherData.Result.CurrentConditions.PrecipLastHr);
            Console.WriteLine("PrecipToday \t\t\t{0}", weatherData.Result.CurrentConditions.PrecipToday);
            Console.WriteLine("WeatherIcon \t\t\t{0}", weatherData.Result.CurrentConditions.WeatherIcon);
            Console.WriteLine("WeatherIconUrl \t\t\t{0}", weatherData.Result.CurrentConditions.WeatherIconUrl);
            Console.WriteLine("Sunrise \t\t\t{0}", weatherData.Result.CurrentConditions.Sunrise);
            Console.WriteLine("Sunset \t\t\t\t{0}", weatherData.Result.CurrentConditions.Sunset);

            Console.WriteLine();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Four Day Forecast");
            Console.WriteLine();

            foreach (var item in weatherData.Result.FourDayForecast)
            {
                Console.WriteLine("Day \t\t\t\t{0}", item.Day);
                Console.WriteLine("------------------------------------");
                Console.WriteLine("ObservationTime \t\t\t\t{0}", item.Day);
                Console.WriteLine("SimpleDescription \t\t{0}", item.SimpleDescription);
                Console.WriteLine("DetailedDescriptionDay \t\t{0}", item.DetailedDescriptionDay);
                Console.WriteLine("DetailedDescriptionNight \t{0}", item.DetailedDescriptionNight);
                Console.WriteLine("HighCelcius \t\t\t{0}", item.HighCelcius);
                Console.WriteLine("LowCelcius \t\t\t{0}", item.LowCelcius);
                Console.WriteLine("RelativeHumidity \t\t{0}", item.RelativeHumidity);
                Console.WriteLine("WindAvgKph \t\t\t{0}", item.WindAvgKph);
                Console.WriteLine("WindGustKph \t\t\t{0}", item.WindGustKph);
                Console.WriteLine("WindDirection \t\t\t{0}", item.WindDirection);
                Console.WriteLine("WindDirection \t\t\t{0}", item.WindDegrees);
                Console.WriteLine("WeatherIcon \t\t\t{0}", item.WeatherIcon);
                Console.WriteLine("WeatherIconUrl \t\t\t{0}", item.WeatherIconUrl);
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
