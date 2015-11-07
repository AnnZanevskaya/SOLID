using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BecomeSolid.Day1
{
   public class CurrencyEntity: IEntity
    {

        public string GetInfo(System.Net.WebResponse response)
        {
           using (var streamReader = new StreamReader(response.GetResponseStream()))
           {
               string responseString = streamReader.ReadToEnd();
               Console.WriteLine(responseString);
               JObject joResponse = JObject.Parse(responseString);
               JObject query = (JObject)joResponse["query"];
               JObject results = (JObject)query["results"];
               JObject rate = (JObject)results["rate"];
               string name = (string)rate["Name"];
               string currency = (string)rate["Rate"];
               string  message = "For " + name + " currency is " + currency;
               Console.WriteLine("Echo Message: {0}", name);
               return message;
           }
        }
    }
}
