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

            Console.WriteLine("Please enter your Zip Code");
            int zip = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Country Code (examples.. US, CA, etc...)");
            string countryCode = Console.ReadLine();

            JObject jObject = JObject.Parse(key);
            JToken token = jObject["ApiKey"];
            string apiKey = token.ToString();

            string url = $"https://api.openweathermap.org/data/2.5/weather?zip={zip},{countryCode}&appid={apiKey}";

            Task<string> response = httpClient.GetStringAsync(url);
            string newResponse = response.Result;
            JObject jObject1 = JObject.Parse(newResponse);

            var temp = jObject1["main"]["temp"].ToString();
            var tempConversion = double.Parse(temp) * 9 / 5 - 459.67;
            tempConversion = Math.Round(tempConversion, 1);
            Console.WriteLine($"The temperature is {tempConversion}");
        }
    }
}
