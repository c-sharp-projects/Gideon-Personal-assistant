using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gideon
{

    class GideonPath
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Theme 1\Gideon";
        public static string Background = path + @"\Background\ios.gif";
    }
    internal class MediaPath
    {
        public static string Path = AppDomain.CurrentDomain.BaseDirectory + @"\Resource\MediaPlayer";
        public static string Next = Path + @"\Icons\Next.png";
        public static string Prev = Path + @"\Icons\Previous.png";
        public static string Play = Path + @"\Icons\Play.png";
        public static string Pause = Path + @"\Icons\Pause.png";

        public static string AudioFile = Path + @"\Media Information\AudioInformation.txt";
        public static string VideoFile = Path + @"\Media Information\VideoInformation.txt";
    }

    class WeatherPath
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Theme 1";
        public static string BgDaySky = path + @"\Weather Forecast\Background\DaySky.jpg";
        public static string BgNightSky = path + @"\Weather Forecast\Background\NightSky.jpg";

        public static string DayClearSky = path + @"\Weather Forecast\Images\DayClearSky.png";
        public static string DayClouds = path + @"\Weather Forecast\Images\DayClouds.png";
        public static string NightClearSky = path + @"\Weather Forecast\Images\NightClearSky.png";
        public static string NightClouds = path + @"\Weather Forecast\Images\NightClouds.png";
        public static string ScatteredClouds = path + @"\Weather Forecast\Images\ScatteredClouds.png";
        public static string BrokenClouds = path + @"\Weather Forecast\Images\BrokenClouds.png";

        public static string SearchIcon = path + @"\Weather Forecast\Icon\Search.png";

        public static string Sunicon = path + @"\Gideon\Weather\Icons\sun.png";
        public static string Moonicon = path + @"\Gideon\Weather\Icons\moon.png";


    }

    class NewsPath
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Theme 1";
        public static string backbtn = path + @"\News\Default\Button icons\back.png";
        public static string Nopreviewimg = path + @"\News\Default\NoPreview.jpg";
        public static string NewsIcon = path + @"\News\Default\news.png";
    }

    class AlarmPath
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Theme 1\Alarm";
        public static string TonePath = path + @"\ChillingMusic.wav";
    }

    class WebAccessPath
    {
        public static string path = AppDomain.CurrentDomain.BaseDirectory + @"\Theme 1\WebAccess";
        public static string GooglePath = path + @"\google.png";
        public static string YoutubePath = path + @"\youtube.png";
        public static string GithubPath = path + @"\github.png";
        public static string GmailPath = path + @"\gmail.png";
        public static string FacebookPath = path + @"\facebook.png";
        public static string DrivePath = path + @"\drive.png";
        public static string MicPath = path + @"\mic.png";
        public static string MicOffPath = path + @"\micoff.png";
        public static string FlashPath = path + @"\flash.png";
        public static string InstaPath = path + @"\insta.png";
    }
}
