using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Xml;
using System.Xml.Linq;

namespace Gideon
{
    class Weather
    {
        const String URL = "http://api.openweathermap.org/data/2.5/weather?q=";
        const String Key = "&mode=xml&appid=bdda109516ac7460899029cc0dc03963";
        double TemperatureCelsius;
        double TemperatureCelsiusMax;
        double TemperatureCelsiusMin;
        double Kelvin = 273.15;

        public string Status { get; set; }
        public string Temperature { get; set; }
        public string MaxTemperature { get; set; }
        public string MinTemperature { get; set; }
        public string City { get; set; }
        public BitmapImage ImageData { get; set; }

        public Weather()
        {
            ParseXML("Pune");
            UpdateInfo();
        }
       

        public void ParseXML(string City)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string xml = GetXmlData(City, client);
                    XDocument xmlDoc = XDocument.Parse(xml);
                    this.City = xmlDoc.Descendants("city").Attributes("name").First().Value;

                    Temperature = xmlDoc.Descendants("temperature").Attributes("value").First().Value;
                    MaxTemperature = xmlDoc.Descendants("temperature").Attributes("max").First().Value;
                    MinTemperature = xmlDoc.Descendants("temperature").Attributes("min").First().Value;                   
                    Status = xmlDoc.Descendants("speed").Attributes("name").First().Value;

                    Location.City = xmlDoc.Descendants("city").Attributes("name").First().Value;
                    Location.Wind = xmlDoc.Descendants("speed").Attributes("value").First().Value;
                    Location.Lastupdate = UtcToLocal(xmlDoc.Descendants("lastupdate").Attributes("value").First().Value);
                    Location.Temperature = xmlDoc.Descendants("temperature").Attributes("value").First().Value;
                    Location.Pressure = xmlDoc.Descendants("pressure").Attributes("value").First().Value;
                    Location.TemperatureMax = xmlDoc.Descendants("temperature").Attributes("max").First().Value;
                    Location.TemperatureMin = xmlDoc.Descendants("temperature").Attributes("min").First().Value;
                    Location.Country = xmlDoc.Descendants("country").First().Value;
                    Location.Sunrise = UtcToLocal(xmlDoc.Descendants("sun").Attributes("rise").First().Value);
                    Location.Sunset = UtcToLocal(xmlDoc.Descendants("sun").Attributes("set").First().Value);
                    Location.WindDir = xmlDoc.Descendants("direction").Attributes("name").First().Value;
                    Location.WindDesc = xmlDoc.Descendants("speed").Attributes("name").First().Value;
                    Location.Cloud = xmlDoc.Descendants("clouds").Attributes("name").First().Value;
                    Location.Humidity = xmlDoc.Descendants("humidity").Attributes("value").First().Value;

                }
            }
            catch (XmlException e)
            {
                GideonBase.SynObj.SpeakAsync("Could not receive accurate data to " + e.Source);
                //SynObj.SpeakAsync("The program will now quit...");
                System.Environment.Exit(1);
            }
            catch (Exception e)
            {
                //SynObj.SpeakAsync(e.Message);
            }
        }
        private string GetXmlData(string city, WebClient client)
        {
            return client.DownloadString(URL + city + Key);
        }
        public void UpdateInfo()
        {
            TemperatureCelsius = Convert.ToDouble(Temperature) - Kelvin;
            TemperatureCelsiusMax = Convert.ToDouble(MaxTemperature) - Kelvin;
            TemperatureCelsiusMin = Convert.ToDouble(MinTemperature) - Kelvin;

            Temperature = Math.Round(TemperatureCelsius, 0) + " ℃";
            MaxTemperature = Math.Round(TemperatureCelsiusMax, 2) + " ℃";
            MinTemperature = Math.Round(TemperatureCelsiusMin, 2) + " ℃";

            if (isDay())
            {
                ImageData = LoadImage(WeatherPath.Sunicon);
            }
            else
            {
                ImageData = LoadImage(WeatherPath.Moonicon);
            }
        }
        private DateTime UtcToLocal(string DateStr)
        {
            DateTime univDateTime;

            univDateTime = DateTime.Parse(DateStr);

            return univDateTime.ToLocalTime();
        }
        public bool isDay()
        {
            bool isDay = true;

            int citySunriseTime = (Location.Sunrise.Hour * 60) + (Location.Sunrise.Minute);
            int currentSystemTime = (DateTime.Now.Hour * 60) + (DateTime.Now.Minute);
            int citySunsetTime = (Location.Sunset.Hour * 60) + (Location.Sunset.Minute);

            if (Location.Sunset.Day == DateTime.Now.Day)
            {
                if (citySunriseTime <= currentSystemTime && currentSystemTime < citySunsetTime)
                {
                    isDay = true;
                }
                else
                {
                    isDay = false;
                }
            }
            else
            {
                citySunsetTime += 24 * 60;

                if (citySunriseTime <= currentSystemTime && currentSystemTime < citySunsetTime)
                {
                    isDay = true;
                }
                else
                {
                    isDay = false;
                }
            }

            return isDay;
        }
        public BitmapImage LoadImage(string url)
        {
            BitmapImage bi = null;
            try
            {
                
                bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(url);
                bi.EndInit();
            }
            catch (Exception e)
            {
               
            }
            return bi;
        }
        
    }

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
