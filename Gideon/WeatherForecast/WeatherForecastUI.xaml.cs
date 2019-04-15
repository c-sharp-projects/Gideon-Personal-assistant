using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gideon.WeatherForecast
{
    /// <summary>
    /// Interaction logic for WeatherForecastUI.xaml
    /// </summary>
    public partial class WeatherForecastUI : Window
    {
        public ImageBrush ImgBrushObj;
        WeatherInformation WIObj;
        public WeatherForecastUI()
        {
            InitializeComponent();
            WIObj = new WeatherInformation();
            ImgBrushObj = new ImageBrush();
            search.Content = new Image { Source = new BitmapImage(new Uri(WeatherPath.SearchIcon)) };
            DisplayInformation("Pune");
        }
        private void UpdateInformation()
        {
            WIObj.TemperatureCelsius = Convert.ToDouble(Location.Temperature) - WIObj.Kelvin;
            WIObj.TemperatureCelsiusMax = Convert.ToDouble(Location.TemperatureMax) - WIObj.Kelvin;
            WIObj.TemperatureCelsiusMin = Convert.ToDouble(Location.TemperatureMin) - WIObj.Kelvin;

            LocationText.Text = Location.City + ", " + Location.Country;
            TemperatureText.Text = Math.Round(WIObj.TemperatureCelsius, 0) + " ℃";
            ClimateStatusText.Text = Location.Cloud;
            UpdateTimeText.Text = "Updated as of  " + Location.Lastupdate.ToShortTimeString();
            TemperatureAgainText.Text = "Feels Like   " + Math.Round(WIObj.TemperatureCelsius, 2) + " ℃";
            PressureText.Text = "Pressure   " + Location.Pressure + "%";
            HumidityText.Text = "Humidity   " + Location.Humidity + "%";
            WindText.Text = "Wind speed   " + Location.Wind + "   km/hr,";
            WindFeelsLikeText.Text = "Feels   " + Location.WindDesc;
            WindDirectionText.Text = "Heading towards   " + Location.WindDir;
            TemperatureMaxText.Text = "Max temperature   " + Math.Round(WIObj.TemperatureCelsiusMax, 2).ToString() + " ℃";
            SunRiseText.Text = "Sunrise   " + Location.Sunrise.ToShortTimeString();
            TemperatureMinText.Text = "Min temperature   " + Math.Round(WIObj.TemperatureCelsiusMin, 2).ToString() + " ℃";
            SunSetText.Text = "Sunset   " + Location.Sunset.ToShortTimeString();
        }
        private void ActionListener(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Uid)
            {
                case "F":

                    TemperatureText.Text = Math.Round(WIObj.CelciusToFahrenheit(WIObj.TemperatureCelsius), 0) + " °F";
                    TemperatureAgainText.Text = "Feels Like   " + Math.Round(WIObj.CelciusToFahrenheit(WIObj.TemperatureCelsius), 2) + " °F";
                    TemperatureMaxText.Text = "Max temperature   " + Math.Round(WIObj.CelciusToFahrenheit(WIObj.TemperatureCelsiusMax), 2) + " °F";
                    TemperatureMinText.Text = "Min temperature   " + Math.Round(WIObj.CelciusToFahrenheit(WIObj.TemperatureCelsiusMin), 2) + " °F";
                    TemperatureButton.Content = "C";
                    TemperatureButton.Uid = "C";

                    break;

                case "C":

                    TemperatureText.Text = Math.Round(WIObj.TemperatureCelsius, 0) + " ℃";
                    TemperatureAgainText.Text = "Feels Like   " + Math.Round(WIObj.TemperatureCelsius, 2) + " ℃";
                    TemperatureMaxText.Text = "Max temperature   " + Math.Round(WIObj.TemperatureCelsiusMax, 2).ToString() + " ℃";
                    TemperatureMinText.Text = "Min temperature   " + Math.Round(WIObj.TemperatureCelsiusMin, 2).ToString() + " ℃";
                    TemperatureButton.Content = "F";
                    TemperatureButton.Uid = "F";
                    break;

                case "search":

                    string text = SearchTextBox.Text;
                    DisplayInformation(text);
                    break;
            }
        }
        public void DisplayInformation(string city)
        {
            WIObj.ParseXML(city);
            SetBackground();
            UpdateInformation();
            //SynObj.SpeakAsync("Right now its " + WeatherForecastUIObj.ClimateStatusText.Text + " and " + WeatherForecastUIObj.TemperatureText.Text);
        }
        private void SetBackground()
        {
            string[] BgImages = { WeatherPath.BgDaySky, WeatherPath.BgNightSky };
            string[] StatusImages = { WeatherPath.DayClearSky, WeatherPath.DayClouds, WeatherPath.NightClearSky, WeatherPath.NightClouds, WeatherPath.ScatteredClouds, WeatherPath.BrokenClouds };
            string ImageName = BgImages[0];
            string StatusImageName = StatusImages[0];
            string ClimateImg = string.Empty;
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


            switch (isDay)
            {
                case true:
                    ImageName = BgImages[0];
                    if (Location.Cloud.Equals("clear sky"))
                    {
                        StatusImageName = StatusImages[0];
                    }
                    else if (Location.Cloud.Equals("few clouds") || Location.Cloud.Equals("overcast clouds")) //(Cayenne)(Moycullen)broken clouds (Hilo)overcast clouds  (Buenaventura) scattered clouds
                    {
                        StatusImageName = StatusImages[1];
                    }
                    else if (Location.Cloud.Equals("scattered clouds"))
                    {
                        StatusImageName = StatusImages[4];
                    }
                    else if (Location.Cloud.Equals("broken clouds"))
                    {
                        StatusImageName = StatusImages[5];
                    }

                    break;

                case false:
                    ImageName = BgImages[1];
                    if (Location.Cloud.Equals("clear sky"))
                    {
                        StatusImageName = StatusImages[2];
                    }
                    else if (Location.Cloud.Equals("few clouds") || Location.Cloud.Equals("overcast clouds"))
                    {
                        StatusImageName = StatusImages[3];
                    }
                    else if (Location.Cloud.Equals("scattered clouds"))
                    {
                        StatusImageName = StatusImages[4];
                    }
                    else if (Location.Cloud.Equals("broken clouds"))
                    {
                        StatusImageName = StatusImages[5];
                    }

                    break;
            }


            ImgBrushObj.ImageSource = new BitmapImage(new Uri(ImageName, UriKind.Relative));
            Background = ImgBrushObj;
            ClimateImage.Source = (ImageSource)new ImageSourceConverter().ConvertFromString(StatusImageName);

        }
        ~WeatherForecastUI()
        {
            ImgBrushObj = null;
            WIObj = null;
        }
    }
}
