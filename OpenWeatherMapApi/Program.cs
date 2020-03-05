using System;
using System.Net.Http;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace OpenWeatherMapApi
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            string key = File.ReadAllText("appsettings.development.json");
#else
            string key = File.ReadAllText("appsettings.release.json");
#endif
            var httpClient = new HttpClient();

        }
    }
}
