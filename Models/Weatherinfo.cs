using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LifeManagementApp.Models
{
    public class WeatherInfo
    {
        public double Temperature { get; set; }

        public double WindSpeed { get; set; }

        public bool IsKitesurfWeather => WindSpeed > 5;
    }
}
