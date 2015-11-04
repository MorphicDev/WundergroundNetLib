using System.Threading.Tasks;

namespace WundergroundNetLib
{
    public interface IJsonDeserializer
    {
        Task<IWundergroundData> JsonToWeatherDataAsync(string jsonData);
    }
}