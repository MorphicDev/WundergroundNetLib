using System.Threading.Tasks;

namespace WundergroundNetLib
{
    public interface IWundergroundDataProvider
    {
        Task<IWundergroundData> GetWundergroundWeatherDataAsync(string stationID);
        Task<IWundergroundData> GetWundergroundWeatherDataAsync(string latitude, string longitude);
        Task<IWundergroundData> GetWundergroundWeatherDataAsync(double latitude, double longitude);
    }
}