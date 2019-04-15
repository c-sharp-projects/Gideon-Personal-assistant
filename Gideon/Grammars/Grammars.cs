using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;

namespace Gideon
{
    class Grammars
    {
      public static string[] mediaPlayerGrammar = { "play","play video", "play audio", "pause", "next", "previous", "stop", "mute", "full volume", "refresh",
                "up", "down","maximize","minimize","increase volume","decrease volume" };

      public static string[] gideonGrammar = { "open mediaplayer", "close mediaplayer", "open music","close music","open game",
                "open WeatherForecast", "open WeatherInformation", "close WeatherForecast",
                "close WeatherInformation","open News","close News","set alarm","set remainder",
                "My Gallery","close My Gallery","Show Command List","Hide Command List"};

      public static string[] weatherForecastGrammar = { "pune", "new york", "chinchwad", "sangli", "brazil", "mexico" };


      public static string[] newsGrammar = { "Business News", "Entertainment News", "General News", "Health News", "Science News", "Sports News", "Technology News" };

      public static  string[] pcinfoGrammar = { "tell me your processor information", "check internet connection", "machine name", "mac address", "ram",
                "username", "who are you", "hello", "how are you","good morning","good night","good evening","what is the time","hello","todays date","battery status","take screenshot"};

        public static Grammar MediaPlayerGrammar
        {
            get
            {
                return new Grammar(new Choices(mediaPlayerGrammar));
            }            
        }
        public static Grammar GideonGrammar
        {
            get
            {
                return new Grammar(new Choices(gideonGrammar));
            }
        }
        public static Grammar WeatherForecastGrammar
        {
            get
            {
                return new Grammar(new Choices(weatherForecastGrammar));
            }
        }

        public static Grammar NewsGrammar
        {
            get
            {
                return new Grammar(new Choices(newsGrammar));
            }
        }

        public static Grammar PcInfoGrammar
        {
            get
            {
                return new Grammar(new Choices(pcinfoGrammar));
            }
        }
        /// <summary>
        /// Grammar functions of all modules
        /// </summary>
        /// <returns></returns>
        //private static Grammar gideonGrammar()
        //{
        //    //string[] action1 = { "open", "close" };
        //    //string[] action2 = { "mediaplayer", "music", "WeatherForecast", "WeatherInformation" };

        //    //GrammarBuilder action1_action2 = new GrammarBuilder(new Choices(action1));
        //    //action1_action2.Append(new Choices(action2));

        //    //Grammar GrammarGenerated = new Grammar(new Choices(action1_action2));

        //    string[] action1 = { "open mediaplayer", "close mediaplayer", "open music","close music",
        //        "open WeatherForecast", "open WeatherInformation", "close WeatherForecast",
        //        "close WeatherInformation","open News","close News","set alarm","set remainder",
        //        "My Gallery","close My Gallery"
        //    };

        //    Grammar GrammarGenerated = new Grammar(new Choices(action1));

        //    return GrammarGenerated;
        //}
        //private static Grammar mediaPlayerGrammar1()
        //{
        //    string[] action1 = { "play","play video", "play audio", "pause", "next", "previous", "stop", "mute", "full volume", "refresh",
        //        "up", "down","maximize","minimize","increase volume","decrease volume" };

        //    Grammar GrammarGenerated = new Grammar(new Choices(action1));

        //    return GrammarGenerated;
        //}
        //private static Grammar weatherForecastGrammar()
        //{
        //    string[] action1 = { "pune","new york","chinchwad","sangli","brazil","mexico" };

        //    Grammar GrammarGenerated = new Grammar(new Choices(action1));

        //    return GrammarGenerated;
        //}

        //private static Grammar newsGrammar()
        //{
        //    string[] action1 = { "Business News", "Entertainment News", "General News", "Health News", "Science News", "Sports News", "Technology News" };

        //    Grammar GrammarGenerated = new Grammar(new Choices(action1));

        //    return GrammarGenerated;
        //}

        //private static Grammar pcinfoGrammar()
        //{
        //    string[] str = { "tell me your processor information", "check internet connection", "machine name", "mac address", "ram",
        //        "username", "who are you", "hello", "how are you","good morning","good night","good evening","what is the time","hello","todays date","battery status"};

        //    Grammar GrammarGenerated = new Grammar(new Choices(str));

        //    return GrammarGenerated;
        //}
    }
}
