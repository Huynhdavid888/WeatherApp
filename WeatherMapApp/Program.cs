using System;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace WeatherMapApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Please enter API key:");
            var apiKey = Console.ReadLine();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Please enter the name of the city you would like to find:");
                var cityName = Console.ReadLine();
                var weatherURL = $"http://api.openweathermap.org/data/2.5/weather?q={cityName}&units=imperial&appid={apiKey}";
                var response = client.GetStringAsync(weatherURL).Result;
                var formattedresponse = JObject.Parse(response).GetValue("main").ToString();
                Console.WriteLine(formattedresponse);
                Console.WriteLine();
                Console.WriteLine("Would you like to choose another city?");
                var userInput = Console.ReadLine();
                Console.WriteLine();
                if (userInput == "no")
                {
                    break;
                }
            }
        }
    }
}
