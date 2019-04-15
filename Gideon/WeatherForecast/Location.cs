using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gideon.WeatherForecast
{
    class Location
    {
        private static string city;
        private static string country;
        private static DateTime sunrise;
        private static DateTime sunset;
        private static string cloud;
        private static string humidity;
        private static DateTime lastupdate;
        private static string wind;
        private static string temperature;
        private static string temperatureMin;
        private static string temperatureMax;
        private static string pressure;
        private static string windDesc;
        private static string windDir;


        public static string City
        {
            get { return city; }
            set { city = value; }
        }

        public static string Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }

        public static string WindDesc
        {
            get { return windDesc; }
            set { windDesc = value; }
        }
        public static string WindDir
        {
            get { return windDir; }
            set { windDir = value; }
        }
        public static string Country
        {
            get { return country; }
            set { country = value; }
        }
        public static string TemperatureMin
        {
            get { return temperatureMin; }
            set { temperatureMin = value; }
        }
        public static string TemperatureMax
        {
            get { return temperatureMax; }
            set { temperatureMax = value; }
        }
        public static DateTime Sunrise
        {
            get { return sunrise; }
            set { sunrise = value; }
        }

        public static DateTime Sunset
        {
            get { return sunset; }
            set { sunset = value; }
        }

        public static string Cloud
        {
            get { return cloud; }
            set { cloud = value; }
        }

        public static string Wind
        {
            get { return wind; }
            set { wind = value; }
        }

        public static string Temperature
        {
            get { return temperature; }
            set { temperature = value; }
        }

        public static string Humidity
        {
            get { return humidity; }
            set { humidity = value; }
        }

        public static DateTime Lastupdate
        {
            get { return lastupdate; }
            set { lastupdate = value; }
        }
    }
}
