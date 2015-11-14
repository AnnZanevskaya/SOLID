using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BecomeSolid.Day1.Entity;
using BecomeSolid.Day1.Service;

namespace BecomeSolid.Day1.Builder
{
    public class WeatherBuilder: IMessageBuilder<WeatherEntity> 
    {   
        public string Build(WeatherEntity entity)
        {
            var message = "In " + entity.Name + " " + entity.Description + " and the temperature is " +
                          entity.Temperature.ToString("+#;-#") + "°C";
            return message;
        }
    }
}
