using System.Threading.Tasks;

namespace WundergroundNetLib.Interfaces
{
    public interface IJsonDeserializer
    {
        Task<IWundergroundData> JsonToWeatherDataAsync(string jsonData);
    }
}