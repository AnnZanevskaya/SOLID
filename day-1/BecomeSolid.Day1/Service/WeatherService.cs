using System;
using System.Linq;
using System.Net;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Helpers;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Service
{
    public class WeatherService : IService<WeatherEntity>
    {
        private string url = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        private string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";

        public WeatherService() { }
        public WeatherService(string url = "", string weatherApiKey = "")
        {
            if (url != String.Empty && url.StartsWith("http"))
                this.url = url;
            if (weatherApiKey != String.Empty)
                this.weatherApiKey = weatherApiKey;
        }
        public WeatherEntity GetInformation(string keyForInformathion)
        {
            string city = keyForInformathion.GetSecondWord(defaulValue: "Minsk");
            WebUtility.UrlEncode(city);

            string responseString = RestHelper.GetResponse(string.Format(url, city, weatherApiKey));
            var weatherResponce = JsonConvert.DeserializeObject<WeatherResponce>(responseString);
            var details = weatherResponce.Weather.First();

            return new WeatherEntity()
            {
                Name = weatherResponce.Name,
                Description = details.Description,
                Temperature = weatherResponce.Main.Temp
            };
        }
    }
}
