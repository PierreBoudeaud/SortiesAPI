using System;
using System.Collections.Generic;

namespace SortiesAPI.Models
{
    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class WeatherJson

    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public Sys sys { get; set; }

        public BO.Weather ConvertToWeatherBO()
        {
            var weather = new BO.Weather();

            weather.Description = this.weather[0].description;
            weather.Humidity = this.main.humidity;
            weather.Icon = this.weather[0].icon;
            weather.Pression = this.main.pressure;
            weather.Sunrise = UnixTimeStampToDateTime(this.sys.sunrise);
            weather.Sunset = UnixTimeStampToDateTime(this.sys.sunset);
            weather.Temperature = this.main.temp;
            weather.WindSpeed = this.wind.speed;
            
            return weather;
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
