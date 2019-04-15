using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

//http://api.openweathermap.org/data/2.5/weather?q=Pune&mode=xml&appid=bdda109516ac7460899029cc0dc03963
namespace Gideon.WeatherForecast
{
    class WeatherInformation
    {
        const String URL = "http://api.openweathermap.org/data/2.5/weather?q=";
        const String Key = "&mode=xml&appid=bdda109516ac7460899029cc0dc03963";

        internal double TemperatureCelsius;
        internal double TemperatureCelsiusMax;
        internal double TemperatureCelsiusMin;
        internal double Kelvin = 273.15;

        public WeatherInformation()
        {

        }
        public void ParseXML(string City)
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    string xml = GetXmlData(City, client);
                    XDocument xmlDoc = XDocument.Parse(xml);
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
        private DateTime UtcToLocal(string DateStr)
        {
            DateTime univDateTime;

            univDateTime = DateTime.Parse(DateStr);

            return univDateTime.ToLocalTime();
        }
        internal double CelciusToFahrenheit(double Celsius)
        {                           // Convertion from Celsius to Fahrenheit and limiting to only 3 digits
            return ((double)((int)(((Celsius * 1.8) + 32) * 1000.0))) / 1000.0;     // after the decimal point
        }
    }
}
