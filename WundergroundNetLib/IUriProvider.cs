using System;

namespace WundergroundNetLib
{
    public interface IUriProvider
    {
        Uri CreateCombinedDataUriFromCoordinates(string latitude, string longitude);
        Uri CreateCombinedDataUriFromCoordinates(double latitude, double longitude);
        Uri CreateCombinedDataUriFromPwsStationID(string stationID);
    }
}