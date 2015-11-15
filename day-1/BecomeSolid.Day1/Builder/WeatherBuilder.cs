using BecomeSolid.Day1.Entity;

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
