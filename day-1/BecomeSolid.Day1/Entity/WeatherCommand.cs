using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BecomeSolid.Day1
{
   public class WeatherCommand: ICommand
    {
       public string GetInfo(WebResponse response)
        {
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                string responseString = streamReader.ReadToEnd();
                Console.WriteLine(responseString);
                JObject joResponse = JObject.Parse(responseString);
                JObject main = (JObject)joResponse["main"];
                double temp = (double)main["temp"];
                JObject weather = (JObject)joResponse["weather"][0];
                string description = (string)weather["description"];
                string cityName = (string)joResponse["name"];

                Console.WriteLine(string.Format("temp is: {0}", temp));
                string message = "In " + cityName + " " + description + " and the temperature is " +
                                  temp.ToString("+#;-#") + "°C";
                return message;
            }
        
        }

       public string GetInfo(string response)
       {
           return response;
       }
    }
}
