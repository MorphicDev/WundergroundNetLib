using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace WundergroundNetLib
{
    public class JsonProvider
    {
        public string DownloadJsonString(Uri uri)
        {
            WebClient webClient = new WebClient();
            return webClient.DownloadString(uri);
        }
    }
}
