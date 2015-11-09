using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces.Data
{
    public interface IWundergroundWeatherData
    {
        IObservationLocationInfo ObservationLocationInfo { get; set; }
        ICurrentConditions CurrentConditions { get; set; }
        List<IForecast> FourDayForecast { get; set; }
    }

    public interface IObservationLocationInfo : IGeneralLocation, IWeatherStationCoordinates, IWundergroundStationID, IWmoNumber { }

    public interface ICurrentConditions : IObservationTime, ISimpleDescription, ICurrentTemperature, IRelativeHumidity, IWind, IPressureMb, IUvIndex, IVisibility, IPrecipitationObservation, IWeatherIcon, ISunriseSunset { }

    public interface IForecast : IOberservationDay, IObservationTime, ISimpleDescription, IDetailedDescriptions, IRelativeHumidity, IWind, IHighLowTemperatures, IWeatherIcon { }
}
