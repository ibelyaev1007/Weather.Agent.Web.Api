using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Weather.Agent.Web.Api
{
    public enum WeatherTypes
    {
        Sunny, // солнечно = 0

        PartlyCloudy, // переменная облачность = 1

        Cloudy, // облачно = 2

        Rainy, // дождливо = 3

        PouringRain, // ливень = 4
    }
}
