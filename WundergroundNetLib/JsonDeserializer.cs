using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace WundergroundNetLib
{
    public class JsonDeserializer
    {
        /// <summary>
        /// Convert json file from string into deserialized WundergroundData object as an asynchronous operation.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public async Task<WundergroundData> JsonToWeatherDataAsync(string jsonData)
        {
            JObject jObject = await ParseJsonFile(jsonData);
            // Deserialize jObject into Weather Data classes
            WundergroundData weatherData = await DeserializeJObjIntoWeatherData(jObject);
            return weatherData;
        }

        /// <summary>
        /// Parse json file into a JObject using Newtonsoft.Json as an asynchronous operation.
        /// </summary>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        internal async Task<JObject> ParseJsonFile(string jsonData)
        {
            return await Task.Run(() => JObject.Parse(jsonData));

            // Task.Run provides a simplier way to schedule a task than Task.Factory.StartNew, 
            // see: http://blogs.msdn.com/b/pfxteam/archive/2011/10/24/10229468.aspx
        }

        /// <summary>
        /// Receives a JObject and deserializes it into a WundergroundData object as asynchronous operation.
        /// 
        /// fourDayForecast needs refactoring to reduce code duplication.
        /// </summary>
        /// <param name="jObject"></param>
        /// <returns></returns>
        internal async Task<WundergroundData> DeserializeJObjIntoWeatherData(JObject jObject)
        {
            WundergroundData weatherData = await Task.Run(() =>
            {
                weatherData = new WundergroundData()
                {
                    observationLocation = new ObservationLocation()
                    {
                        City = (string)jObject["current_observation"]["display_location"]["city"],
                        //City = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["icon"],
                        Country = (string)jObject["current_observation"]["observation_location"]["country_iso3166"],
                        StationLatitude = (double)jObject["current_observation"]["observation_location"]["latitude"],
                        StationLongitude = (double)jObject["current_observation"]["observation_location"]["longitude"],
                        StationElevation = (string)jObject["current_observation"]["observation_location"]["elevation"],
                        StationID = (string)jObject["current_observation"]["station_id"],
                        WmoNumber = (int)jObject["current_observation"]["display_location"]["wmo"]
                    },
                    currentConditions = new CurrentConditions()
                    {
                        ObservationTime = (DateTime)jObject["current_observation"]["observation_time_rfc822"], // observation_time_rfc822 : "Fri, 30 Oct 2015 07:56:47 +1300"
                        CurrentDescription = (string)jObject["current_observation"]["weather"], // weather : "Rain"
                        TempCelsius = (double)jObject["current_observation"]["temp_c"], // temp_c : 4.9 - convert to double
                        RelativeHumidity = (string)jObject["current_observation"]["relative_humidity"], // relative_humidity : "86%"
                        WindDescription = (string)jObject["current_observation"]["wind_string"], // wind_string : "From the WSW at 1.0 MPH Gusting to 2.0 MPH"
                        WindDirection = (string)jObject["current_observation"]["wind_dir"], // wind_dir : "WSW" ---> Could change this to enum
                        WindDegrees = (int)jObject["current_observation"]["wind_degrees"],  // wind_degrees : 247
                        WindAvgKph = (double)jObject["current_observation"]["wind_kph"], // wind_kph : 1.6
                        WindGustKph = (double)jObject["current_observation"]["wind_gust_kph"], // wind_gust_kph : "3.2" - this will need to be converted to double
                        PressureMb = (int)jObject["current_observation"]["pressure_mb"], // pressure_mb : "1005" - Convert to int?
                        UVIndex = (double)jObject["current_observation"]["UV"],  // UV : "0" - convert to int or double?
                        VisibilityKm = (double)jObject["current_observation"]["UV"], // visibility_km : "10.0"
                        PrecipLastHr = (double)jObject["current_observation"]["precip_1hr_metric"], // precip_1hr_metric : " 1"
                        PrecipToday = (double)jObject["current_observation"]["precip_today_metric"],  // precip_today_metric : "1"
                        WeatherIcon = (string)jObject["current_observation"]["icon"], // icon : "rain"
                        WeatherIconUrl = (string)jObject["current_observation"]["icon_url"], // icon_url : "http://icons.wxug.com/i/c/k/rain.gif"
                        Sunrise = string.Format("{0}:{1}", (string)jObject["sun_phase"]["sunrise"]["hour"], (string)jObject["sun_phase"]["sunrise"]["minute"]),  // sun_phase / sunrise / hour : "6" / minute : "18"
                        Sunset = string.Format("{0}:{1}", (string)jObject["sun_phase"]["sunset"]["hour"], (string)jObject["sun_phase"]["sunset"]["minute"]),
                    },
                    fourDayForecast = new List<Forecast>()
                    {
                        new Forecast()
                        {
                            Day = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["date"]["weekday_short"], // simpleforecast / forecastday / date / weekday_short
                            Date = new DateTime((int)jObject["forecast"]["simpleforecast"]["forecastday"][0]["date"]["year"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][0]["date"]["month"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][0]["date"]["day"]),  // simpleforecast / forecastday / date / year, month, day
                            SimpleDescription = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["conditions"], // simpleforecast / forecastday / conditions : "Chance of Rain"
                            DetailedDescriptionDay = (string)jObject["forecast"]["txt_forecast"]["forecastday"][0]["fcttext_metric"], // txt_forecast / Even Number / "Cloudy this morning with showers during the afternoon. High 17C. Winds S at 15 to 30 km/h. Chance of rain 40%." 
                            DetailedDescriptionNight = (string)jObject["forecast"]["txt_forecast"]["forecastday"][1]["fcttext_metric"], // txt_forecast / Odd Number / "Partly cloudy skies. Low 11C. Winds SE at 10 to 15 km/h."
                            HighCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][0]["high"]["celsius"], // simpleforecast / forecastday / high / celsius
                            LowCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][0]["low"]["celsius"], // simpleforecast / forecastday / low / celsius
                            RelativeHumidity = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["avehumidity"],
                            WindAvgKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][0]["avewind"]["kph"],  // simpleforecast / forecastday / avewind / kph : 32
                            WindGustKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][0]["maxwind"]["kph"],  // simpleforecast / forecastday / maxwind / kph : 32
                            WindDirection = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["avewind"]["dir"], // simpleforecast / forecastday / avewind / dir : "S"
                            WeatherIcon = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["icon"], // simpleforecast / forecastday / icon : "chancerain"
                            WeatherIconUrl = (string)jObject["forecast"]["simpleforecast"]["forecastday"][0]["icon_url"],
                        },
                        new Forecast()
                        {
                            Day = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["date"]["weekday_short"], // simpleforecast / forecastday / date / weekday_short
                            Date = new DateTime((int)jObject["forecast"]["simpleforecast"]["forecastday"][1]["date"]["year"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][1]["date"]["month"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][1]["date"]["day"]),  // simpleforecast / forecastday / date / year, month, day
                            SimpleDescription = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["conditions"], // simpleforecast / forecastday / conditions : "Chance of Rain"
                            DetailedDescriptionDay = (string)jObject["forecast"]["txt_forecast"]["forecastday"][2]["fcttext_metric"], // txt_forecast / Even Number / "Cloudy this morning with showers during the afternoon. High 37C. Winds S at 35 to 31 km/h. Chance of rain 41%." 
                            DetailedDescriptionNight = (string)jObject["forecast"]["txt_forecast"]["forecastday"][3]["fcttext_metric"], // txt_forecast / Odd Number / "Partly cloudy skies. Low 33C. Winds SE at 31 to 35 km/h."
                            HighCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][1]["high"]["celsius"], // simpleforecast / forecastday / high / celsius
                            LowCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][1]["low"]["celsius"], // simpleforecast / forecastday / low / celsius
                            RelativeHumidity = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["avehumidity"],
                            WindAvgKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][1]["avewind"]["kph"],  // simpleforecast / forecastday / avewind / kph : 33
                            WindGustKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][1]["maxwind"]["kph"],  // simpleforecast / forecastday / maxwind / kph : 33
                            WindDirection = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["avewind"]["dir"], // simpleforecast / forecastday / avewind / dir : "S"
                            WeatherIcon = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["icon"], // simpleforecast / forecastday / icon : "chancerain"
                            WeatherIconUrl = (string)jObject["forecast"]["simpleforecast"]["forecastday"][1]["icon_url"],
                        },
                        new Forecast()
                        {
                            Day = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["date"]["weekday_short"], // simpleforecast / forecastday / date / weekday_short
                            Date = new DateTime((int)jObject["forecast"]["simpleforecast"]["forecastday"][2]["date"]["year"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][2]["date"]["month"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][2]["date"]["day"]),  // simpleforecast / forecastday / date / year, month, day
                            SimpleDescription = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["conditions"], // simpleforecast / forecastday / conditions : "Chance of Rain"
                            DetailedDescriptionDay = (string)jObject["forecast"]["txt_forecast"]["forecastday"][4]["fcttext_metric"], // txt_forecast / Even Number / "Cloudy this morning with showers during the afternoon. High 37C. Winds S at 35 to 32 km/h. Chance of rain 42%." 
                            DetailedDescriptionNight = (string)jObject["forecast"]["txt_forecast"]["forecastday"][5]["fcttext_metric"], // txt_forecast / Odd Number / "Partly cloudy skies. Low 33C. Winds SE at 32 to 35 km/h."
                            HighCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][2]["high"]["celsius"], // simpleforecast / forecastday / high / celsius
                            LowCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][2]["low"]["celsius"], // simpleforecast / forecastday / low / celsius
                            RelativeHumidity = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["avehumidity"],
                            WindAvgKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][2]["avewind"]["kph"],  // simpleforecast / forecastday / avewind / kph : 33
                            WindGustKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][2]["maxwind"]["kph"],  // simpleforecast / forecastday / maxwind / kph : 33
                            WindDirection = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["avewind"]["dir"], // simpleforecast / forecastday / avewind / dir : "S"
                            WeatherIcon = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["icon"], // simpleforecast / forecastday / icon : "chancerain"
                            WeatherIconUrl = (string)jObject["forecast"]["simpleforecast"]["forecastday"][2]["icon_url"],
                        },
                        new Forecast()
                        {
                            Day = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["date"]["weekday_short"], // simpleforecast / forecastday / date / weekday_short
                            Date = new DateTime((int)jObject["forecast"]["simpleforecast"]["forecastday"][3]["date"]["year"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][3]["date"]["month"],(int)jObject["forecast"]["simpleforecast"]["forecastday"][3]["date"]["day"]),  // simpleforecast / forecastday / date / year, month, day
                            SimpleDescription = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["conditions"], // simpleforecast / forecastday / conditions : "Chance of Rain"
                            DetailedDescriptionDay = (string)jObject["forecast"]["txt_forecast"]["forecastday"][6]["fcttext_metric"], // txt_forecast / Even Number / "Cloudy this morning with showers during the afternoon. High 37C. Winds S at 35 to 33 km/h. Chance of rain 43%." 
                            DetailedDescriptionNight = (string)jObject["forecast"]["txt_forecast"]["forecastday"][7]["fcttext_metric"], // txt_forecast / Odd Number / "Partly cloudy skies. Low 33C. Winds SE at 33 to 35 km/h."
                            HighCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][3]["high"]["celsius"], // simpleforecast / forecastday / high / celsius
                            LowCelcius = (double)jObject["forecast"]["simpleforecast"]["forecastday"][3]["low"]["celsius"], // simpleforecast / forecastday / low / celsius
                            RelativeHumidity = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["avehumidity"],
                            WindAvgKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][3]["avewind"]["kph"],  // simpleforecast / forecastday / avewind / kph : 33
                            WindGustKph = (double)jObject["forecast"]["simpleforecast"]["forecastday"][3]["maxwind"]["kph"],  // simpleforecast / forecastday / maxwind / kph : 33
                            WindDirection = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["avewind"]["dir"], // simpleforecast / forecastday / avewind / dir : "S"
                            WeatherIcon = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["icon"], // simpleforecast / forecastday / icon : "chancerain"
                            WeatherIconUrl = (string)jObject["forecast"]["simpleforecast"]["forecastday"][3]["icon_url"],
                        },
                    },
                };
                return weatherData;
            });
            return weatherData;
        }
    }
}
