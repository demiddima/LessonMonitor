using LessonMonitorAPICore8.Models;
using Microsoft.AspNetCore.Mvc;

namespace LessonMonitorAPICore8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
            })
            .ToArray();
        }

        [HttpGet("model")]
        public WeatherForecast GetTypeWeatherForecast()
        {
            Type typeWeatherForecast = typeof(WeatherForecast);

            var constructors = typeWeatherForecast.GetConstructors();
            var defaultConstructor = constructors.FirstOrDefault(x => x.GetParameters().Length == 0);

            var obj = defaultConstructor.Invoke(null); 

            var properties = typeWeatherForecast.GetProperties();

            foreach (var property in properties)
            {
                if(_weatherForecast.TryGetValue(property.Name, out var value))
                {
                    if(property.PropertyType.Name == "DateTime")
                    {
                        var date =  DateTime.Parse(value);

                        property.SetValue(obj, date);
                    }

                    if (property.PropertyType.Name == "Int32")
                    {
                        var tempC = int.Parse(value);

                        property.SetValue(obj, tempC);
                    }

                    if (property.PropertyType.Name == "string")
                    {
                        property.SetValue(obj, value);
                    }
                }

            }
            return (WeatherForecast)obj;
        }


        private Dictionary<string, string> _weatherForecast = new Dictionary<string, string>
        {
            {"Date", DateTime.Now.ToString() },
            {"TemperatureC", "234"},
            {"Summary", Guid.NewGuid().ToString() }
        };


    }
}
