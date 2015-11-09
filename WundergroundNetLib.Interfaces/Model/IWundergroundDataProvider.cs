using System.Threading.Tasks;
using WundergroundNetLib.Interfaces.Data;

namespace WundergroundNetLib.Interfaces.Model
{
    public interface IWundergroundDataProvider
    {
        Task<IWundergroundWeatherData> GetWundergroundWeatherDataAsync(string stationID);
        Task<IWundergroundWeatherData> GetWundergroundWeatherDataAsync(string latitude, string longitude);
        Task<IWundergroundWeatherData> GetWundergroundWeatherDataAsync(double latitude, double longitude);
    }
}