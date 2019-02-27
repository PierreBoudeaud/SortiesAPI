using System;

namespace BO
{
    public class Weather: AbstractIdentifiable
    {
        public float Temperature { get; set; }

        public float WindSpeed { get; set; }

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

        public Guid ExcursionId { get; set; }

        public Excursion Excursion { get; set; }
    }
}
