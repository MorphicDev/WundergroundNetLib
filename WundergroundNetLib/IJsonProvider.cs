using System;
using System.Threading.Tasks;

namespace WundergroundNetLib
{
    public interface IJsonProvider
    {
        string DownloadJsonString(Uri uri);
        Task<string> DownloadJsonStringAsync(Uri uri);
    }
}