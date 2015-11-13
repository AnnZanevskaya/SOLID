using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using Newtonsoft.Json;

namespace BecomeSolid.Day1.Service
{
    public class WeatherService : IService<WeatherEntity>
    {
        private string url = "http://api.openweathermap.org/data/2.5/weather?q={0}&APPID={1}&units=metric";
        private string weatherApiKey = "ec259b32688dc1c1d087ebc30cbff9ed";
        public WeatherEntity GetInformation(string keyForInformathion)
        {

            var messageParts = keyForInformathion.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var city = messageParts.Length == 1 ? "Minsk" : messageParts.Skip(1).First();

            WebUtility.UrlEncode(city);
            WebRequest request = WebRequest.Create(string.Format(url, city, weatherApiKey));
            WebResponse response = request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();

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
}
