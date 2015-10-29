using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Threading;

namespace WundergroundNetLib
{
    public class JsonProvider
    {
        /// <summary>
        /// Download json string using the legacy WebClient class as a synchronous operation
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public string DownloadJsonString(Uri uri)
        {
            WebClient webClient = new WebClient();
            // Uncomment Thread.Sleep for performance testing purposes on the GetData method
            // Thread.Sleep(10000);
            return webClient.DownloadString(uri);
        }

        /// <summary>
        /// Send a GET request using HttpClient and download a json string from specified Uri as an asynchronous operation.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> DownloadJsonStringAsync(Uri uri)
        {
            string uriContent = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            uriContent = await response.Content.ReadAsStringAsync();
            // Uncomment Thread.Sleep for performance testing purposes on the GetDataAsync method
            // Thread.Sleep(10000);
            return uriContent;
        }
    }
}
