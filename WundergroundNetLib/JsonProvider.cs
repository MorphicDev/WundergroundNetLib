using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace WundergroundNetLib
{
    public class JsonProvider
    {
        // Legacy code
        public string DownloadJsonString(Uri uri)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadString(uri);
        }

        /// <summary>
        /// This method does the same job as previous DownloadJsonString method, 
        /// but this time we download JSON string asynchronously using HttpClient. 
        /// This is implemented to improve application responsiveness.
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public async Task<string> DownloadJsonStringAsync(Uri uri)
        {
            string uriContent = null;
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(uri);
            uriContent = await response.Content.ReadAsStringAsync();
            return uriContent;
        }
    }
}
