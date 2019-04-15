using Gideon.Codes;
using Gideon.Media;
using Gideon.News;
using Gideon.WeatherForecast;
using Gideon.Gallery;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;


namespace Gideon
{
    class ModulesHandler
    {
        Hashtable ModuleTableObj;
        MediaPlayerUI MediaPlayerObj;
        WeatherForecastUI WeatherForecastObj;
        NewsUI NewsObj;
        GalleryUserInterface GalleryObj;
       
        public ModulesHandler()
        {
            ModuleTableObj = new Hashtable();
            MediaPlayerObj = null;
            WeatherForecastObj = null;
            GalleryObj = null;
        }
        public bool IsRunning(Modules module)
        {
            bool bRet = false;

            if (ModuleTableObj.ContainsKey(module))
            {
                bRet = true;
            }
            return bRet;
        }
        public void OpenModule(Modules module)
        {
            if (IsRunning(module))
            {
                GideonBase.SynObj.SpeakAsync("This application is already running !");
                return;
            }

            switch (module)
            {
                case Modules.MediaPlayer:

                    MediaPlayerObj = new MediaPlayerUI();
                    ModuleTableObj.Add(module, MediaPlayerObj);
                    MediaPlayerObj.Show();
                    //MediaPlayerObj.Visibility = System.Windows.Visibility.Hidden;
                                        
                    break;

                case Modules.WeatherForecast:

                    WeatherForecastObj = new WeatherForecastUI();
                    ModuleTableObj.Add(module, WeatherForecastObj);
                    WeatherForecastObj.Show();

                    break;

                case Modules.News:

                    NewsObj = new NewsUI();
                    ModuleTableObj.Add(module, NewsObj);
                    NewsObj.Show();

                    break;

                case Modules.Gallery:

                    GalleryObj = new GalleryUserInterface();
                    ModuleTableObj.Add(module, GalleryObj);
                    GalleryObj.Show();

                    break;

            }
            
        }
        public void CloseModule(Modules module)
        {
            if (!IsRunning(module))
            {
                GideonBase.SynObj.SpeakAsync("This application is already close or not in running state !");
                return;
            }

            switch (module)
            {
                case Modules.MediaPlayer:
                    MediaPlayerObj.Close();
                    MediaPlayerObj = null;
                    break;

                case Modules.WeatherForecast:
                    WeatherForecastObj.Close();
                    WeatherForecastObj = null;
                    break;

                case Modules.News:
                    NewsObj.Close();
                    NewsObj = null;
                    break;

                case Modules.Gallery:
                    GalleryObj.Close();
                    GalleryObj = null;
                    break;

            }

           
            GC.SuppressFinalize(ModuleTableObj[module]);    
            GC.Collect();
            ModuleTableObj[module] = null;
            ModuleTableObj.Remove(module);
        }
        public void MediaPlayerHandler(string commands,Song songname)
        {
            
            if (MediaPlayerObj == null)
            {
                return;
            }
            try
            {
                switch (commands)
                {
                    case "play":
                        MediaPlayerObj.PlaySong(MediaCodes.Play, songname);
                        break;

                    case "play video":
                        MediaPlayerObj.PlaySong(MediaCodes.PlayVideo, songname);
                       // MediaPlayerObj.Visibility = System.Windows.Visibility.Visible;
                        break;

                    case "play audio":
                       // MediaPlayerObj.Visibility = System.Windows.Visibility.Hidden;
                        MediaPlayerObj.PlaySong(MediaCodes.PlayAudio, songname);
                        break;

                    case "next":
                        MediaPlayerObj.NextSong(songname);
                        break;

                    case "previous":
                        MediaPlayerObj.PreviousSong(songname);
                        break;

                    case "stop":
                        MediaPlayerObj.StopSong(songname);
                        break;

                    case "pause":
                        MediaPlayerObj.PauseSong(songname);
                        break;

                    case "up":
                    case "increase volume":
                        MediaPlayerObj.AdjustVolume(MediaCodes.IncreaseVolume, songname);
                        break;

                    case "down":
                    case "decrease volume":
                        MediaPlayerObj.AdjustVolume(MediaCodes.DecreaseVolume, songname);
                        break;

                    case "mute":
                        MediaPlayerObj.AdjustVolume(MediaCodes.Mute, songname);
                        break;

                    case "full volume":
                        MediaPlayerObj.AdjustVolume(MediaCodes.FullVolume, songname);
                        break;

                    case "maximize":
                        MediaPlayerObj.SetWindow(MediaCodes.Maximize, songname);
                        break;

                    case "minimize":
                        MediaPlayerObj.SetWindow(MediaCodes.Minimize, songname);
                        break;

                }
            }
            catch (Exception e)
            {
                GideonBase.SynObj.SpeakAsync(e.Message);
            }
        }
        //public void WeatherForecastHandler(string commands)
        //{
        //    if (WeatherForecastObj == null)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        switch (commands)
        //        {
        //            case "pune":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //            case "new york":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //            case "chinchwad":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //            case "sangli":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //            case "brazil":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //            case "mexico":
        //                WeatherForecastObj.DisplayInformation(commands);
        //                break;

        //        }
                
        //    }
        //    catch (Exception e)
        //    {
        //        GideonBase.SynObj.SpeakAsync(e.Message);
        //    }
        //}
        public void NewsHandler(string commands)
        {
            if (NewsObj == null)
            {
                return;
            }
            try
            {
                switch (commands)
                {
                    case "Business News":
                        NewsObj.GetNews(commands);
                        break;
                    case "Entertainment News":
                        NewsObj.GetNews(commands);
                        break;
                    case "General News":
                        NewsObj.GetNews(commands);
                        break;
                    case "Health News":
                        NewsObj.GetNews(commands);
                        break;
                    case "Science News":
                        NewsObj.GetNews(commands);
                        break;
                    case "Sports News":
                        NewsObj.GetNews(commands);
                        break;
                    case "Technology News":
                        NewsObj.GetNews(commands);
                        break;

                }

            }
            catch (Exception e)
            {
                GideonBase.SynObj.SpeakAsync(e.Message);
            }
        }
    }
}
