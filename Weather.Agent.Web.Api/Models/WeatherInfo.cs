using System;

namespace Weather.Agent.Web.Api.Models
{
    public class WeatherInfo
    {
        public int Id { get; set; }
        public int MinTemperature { get; set; }

        public int MaxTemperature { get; set; }

        public string City { get; set; }

        public DateTime Date { get; set; }

        public WeatherTypes WeatherType { get; set; }
    }
}
