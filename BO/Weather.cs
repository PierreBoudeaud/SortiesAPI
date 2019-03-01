using Newtonsoft.Json;
using System;

namespace BO
{
    public class Weather: AbstractIdentifiable
    {
        public double Temperature { get; set; }

        public double WindSpeed { get; set; }

        public int Pression { get; set; }

        public int Humidity { get; set; }

        public string Description { get; set; }

        private string _icon;

        public string Icon
        {
            get => _icon;
            set => _icon = $"http://openweathermap.org/img/w/{value}.png";
        }

        public DateTime Sunrise { get; set; }

        public DateTime Sunset { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
