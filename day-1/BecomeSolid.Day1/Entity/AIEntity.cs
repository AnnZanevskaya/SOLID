using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace BecomeSolid.Day1.Entity
{
    public class AIEntity : IEntity
    {
        public string GetInfo(System.Net.WebResponse response)
        {
            throw new NotImplementedException(); //нельзя так делать :С
        }

        public string GetInfo(string response) //тоже херня какая-то
        {
            if (response.Contains("your name"))
            {
                return "my name is ann";
            }
            else if (response.Contains("weather"))
            {
                MessageAnalizer analizer = new MessageAnalizer("/weather");
                ResponceService service = new ResponceService(analizer.Url, analizer.Entity);
                return service.GetResponse();
            }
            else if (response.Contains("currency"))
            {
                MessageAnalizer analizer = new MessageAnalizer("/currency");
                ResponceService service = new ResponceService(analizer.Url, analizer.Entity);
                return service.GetResponse();
            }
            return response;
        }
    }
}

