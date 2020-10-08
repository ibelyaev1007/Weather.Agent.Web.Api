using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Weather.Agent.Web.Api.Models;


namespace Weather.Agent.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class WeatherInfoController : Controller
    {
        private static List<WeatherInfo> weatherInfoList = new List<WeatherInfo>
        {
            new WeatherInfo
            {
                Id = 1,
                City = "Minsk",
                Date = DateTime.Today,
                MinTemperature = 25,
                MaxTemperature = 28,
                WeatherType = WeatherTypes.Sunny
            },
            new WeatherInfo
            {
                Id = 2,
                City = "Minsk",
                Date = DateTime.Today.AddDays(1),
                MinTemperature = 23,
                MaxTemperature = 26,
                WeatherType = WeatherTypes.PartlyCloudy
            },
        };

        // GET api/weatherInfo
        [HttpGet]
        public IEnumerable<WeatherInfo> Get()
        {
            return weatherInfoList;
        }

        // GET api/weatherInfo/2
        [HttpGet("{id}")]
        public WeatherInfo Get(int id)
        {
            return weatherInfoList.FirstOrDefault(wi => wi.Id == id);
        }

        // POST api/weatherInfo
        [HttpPost]
        public ActionResult Post([FromBody] WeatherInfo weatherInfo)
        {
            if (weatherInfoList.Any(w => w.Id == weatherInfo.Id))
            {
                return this.StatusCode((int) HttpStatusCode.Conflict);
            }

            weatherInfoList.Add(weatherInfo);
            return this.Ok();
        }

        // PUT api/weatherInfo/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] WeatherInfo weatherInfo)
        {
            var index = weatherInfoList.FindIndex(w => w.Id == id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }

            weatherInfoList.RemoveAt(index);
            weatherInfoList.Add(weatherInfo);

            return this.Ok();
        }

        // DELETE api/weatherInfo/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var index = weatherInfoList.FindIndex(w => w.Id == id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }

            weatherInfoList.RemoveAt(index);

            return this.Ok();
        }

        // PATCH api/weatherInfo/5
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody]WeatherInfo value)
        {
            var index = weatherInfoList.FindIndex(w => w.Id == id);
            if (index < 0)
            {
                return this.StatusCode((int)HttpStatusCode.NotFound);
            }

            if (value.City != null)
            {
                weatherInfoList.ElementAt(index).City = value.City;
                return this.Ok();
            }

            return this.StatusCode((int) HttpStatusCode.NotModified);
        }
    }
}
