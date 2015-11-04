using System.Collections.Generic;

namespace WundergroundNetLib
{
    public interface IWundergroundData
    {
        ICurrentConditions currentConditions { get; set; }
        IObservationLocation observationLocation { get; set; }

        List<IForecast> fourDayForecast { get; set; }
    }
}