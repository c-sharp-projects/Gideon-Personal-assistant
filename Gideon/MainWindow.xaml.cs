using Gideon.Alarm;
using Gideon.Codes;
using Gideon.Gallery;
using Gideon.Media;
using Gideon.MotivationalQuotes;
using Gideon.Remainder;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Media;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using WpfAnimatedGif;

namespace Gideon
{
    public partial class GideonBase : Window
    {
        SpeechRecognitionEngine EngineObj;
        public static SpeechSynthesizer SynObj;
        ModulesHandler MHObj;
        Hashtable GrammarTableObj;
        public DispatcherTimer Timer;
        public DispatcherTimer dispatcherTimer;
        RemainderUI RemainderObj;
        GalleryUI GalleryObj;
        Alaram aobj;
        int remainderTime = 0;
        bool flag = false;
        string[] quotes;
        int quotesCount = 0;

        public GideonBase()
        {
            InitializeComponent();
          //  var image = new BitmapImage();
             
         //   ImageBehavior.SetAnimatedSource(BgImage, (ImageSource) new ImageSourceConverter().ConvertFromString(GideonPath.Background));
            GrammarTableObj = new Hashtable();
            RemainderObj = new RemainderUI();
            RemainderUI.ReadFromFile();
            GalleryObj = new GalleryUI();
            aobj = new Alaram();
            try
            {
                EngineObj = new SpeechRecognitionEngine(new System.Globalization.CultureInfo("en-IN"));
                EngineObj.SetInputToDefaultAudioDevice();
                SynObj = new SpeechSynthesizer { Volume = 100 };
                SynObj.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Teen, 18, System.Globalization.CultureInfo.CurrentUICulture);
                LoadGrammar(Modules.Gideon, Grammars.GideonGrammar);
                LoadGrammar(Modules.PcInfo, Grammars.PcInfoGrammar);
                EngineObj.RecognizeAsync(RecognizeMode.Multiple);
                EngineObj.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(Engine_SpeechRecognized);


                MHObj = new ModulesHandler();
                MHObj.OpenModule(Modules.Remainder);

                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(alaramTimer);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);


                Timer = new DispatcherTimer();
                Timer.Tick += new EventHandler(showTime);
                Timer.Interval = new TimeSpan(0, 0, 1);
                Timer.Start();

                date.Content = DateTime.Now.Date.ToShortDateString();
                DateTimeGrid.ToolTip = DateTime.Now.ToString("F");
                setBackgrounds();
                WeatherUpdate();
                NewsUpdate();
                SetValues();
                quotes = Motivational_Quotes.FetchQuotes();
                Greet();

            }
            catch (System.Net.WebException)
            {

            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

        }
        private void Greet()
        {
            string UserName = Environment.UserName;
            string sRet = null;

            if (DateTime.Now.Hour < 12)
            {
                sRet = "Good morning, " + UserName + " how can i help you";
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour <= 18)
            {
                sRet = "Good afternoon," + UserName + " how can i help you";
            }
            else
            {
                sRet = "Good evening, " + UserName + " how can i help you";
            }
            SynObj.SpeakAsync(sRet);
        }
        public void alaramTimer(object obj, EventArgs e)
        {


            if (DateTime.Now.Hour % 12 == aobj.alarmtime.Hour % 12 && DateTime.Now.Minute == aobj.alarmtime.Minute && DateTime.Now.Second == aobj.alarmtime.Second)
            {
               // alaram_grid.Visibility = Visibility.Visible;

                dispatcherTimer.Stop();

                try
                {
                   // alaram_grid.Visibility = Visibility.Visible;
                    if (AlaramNote.Text.Length == 0)
                    {
                        aobj.tone = new SoundPlayer();
                        aobj.tone.SoundLocation = AlarmPath.TonePath;
                        aobj.tone.PlayLooping();
                    }
                    else
                    {
                        int counter = 0;
                        while (counter++ != 2)
                            SynObj.SpeakAsync(Environment.UserName + AlaramNote.Text);
                    }
                }
                catch (Exception e1)
                {
                    MessageBox.Show("Error : " + e1);
                }
            }
        }
        public void SetValues()
        {
            textboxHour.Text = DateTime.Now.Hour.ToString();
            textboxMinute.Text = DateTime.Now.Minute.ToString();
            textboxSecond.Text = DateTime.Now.Second.ToString();
            textboxMeridate.Text = DateTime.Now.Hour < 12 ? "AM" : "PM";

            textboxDate.Text = (DateTime.Now.Day).ToString();
            textboxMonth.Text = RemainderObj.month[DateTime.Now.Month - 1];
        }
        private void LoadGrammar(Modules module,Grammar Gobj)
        {
            EngineObj.LoadGrammarAsync(Gobj);

            if (!GrammarTableObj.ContainsKey(module))
            {
                GrammarTableObj.Add(module, Gobj);
            }                       
        }
        private void UnLoadGrammar(Modules module)
        {
            EngineObj.UnloadAllGrammars();

            if (GrammarTableObj.ContainsKey(module))
            {
                GrammarTableObj[module] = null;
                GrammarTableObj.Remove(module);
            }


            foreach (DictionaryEntry obj in GrammarTableObj)
            {
                 LoadGrammar((Modules)obj.Key, (Grammar)obj.Value);
            }

        }

        //private static Grammar GenerateGrammar()
        //{
        //    string[] spaction1 = {"What"};
        //    string[] spaction2 = {"is"};
        //    string[] action1 = { "good", "today's","the","your","Who","Media"};
        //    string[] action2 = { "morning", "evening", "night","date","time","name","created you","Player" };

        //    GrammarBuilder action1_action2 = new GrammarBuilder(new Choices(action1));
        //    action1_action2.Append(new Choices(action2));

        //    GrammarBuilder spaction1_spaction2_action1_action2 = new GrammarBuilder(new Choices(spaction1));
        //    spaction1_spaction2_action1_action2.Append(new Choices(spaction2));
        //    spaction1_spaction2_action1_action2.Append(new Choices(action1));
        //    spaction1_spaction2_action1_action2.Append(new Choices(action2));

        //    Grammar GrammarGenerated = new Grammar(new Choices(action1_action2, spaction1_spaction2_action1_action2));

        //    return GrammarGenerated;
        //}
        public void Engine_SpeechRecognized(object Object, SpeechRecognizedEventArgs e)
        {
            switch (e.Result.Text)
            {
                /// <summary>
                /// Media Player
                /// </summary>
                /// <returns></returns>
                case "open music":
                case "open mediaplayer":
                    LoadGrammar(Modules.MediaPlayer,Grammars.MediaPlayerGrammar);
                    MHObj.OpenModule(Modules.MediaPlayer);
                    break;

                case "close music":
                case "close mediaplayer":                  
                    MHObj.CloseModule(Modules.MediaPlayer);
                    UnLoadGrammar(Modules.MediaPlayer);
                    songTB.Text = "";
                    break;

                case "play":
                case "play video":
                case "play audio":
                case "next":
                case "previous":
                case "stop":
                case "pause":
                case "up":
                case "increase volume":
                case "down":
                case "decrease volume":
                case "mute":
                case "full volume":
                case "maximize":                  
                case "minimize":
                    Song songname = new Song();
                    MHObj.MediaPlayerHandler(e.Result.Text,songname);
                    mediaplayergrid.DataContext = songname;
                    break;
                /////////////////////////////////////////////////////////////////////////////////////////

                /// <summary>
                /// weather forecast
                /// </summary>
                /// <returns></returns>
                /// 
                case "open WeatherForecast":
                case "open WeatherInformation":
                //    LoadGrammar(Modules.WeatherForecast, Grammars.WeatherForecastGrammar);
                    MHObj.OpenModule(Modules.WeatherForecast);
                    break;

                case "close WeatherForecast":
                case "close WeatherInformation":
                    MHObj.CloseModule(Modules.WeatherForecast);
                  //  UnLoadGrammar(Modules.WeatherForecast);
                    break;
                //case"pune":
                //case "new york":
                //case "chinchwad":
                //case "sangli":
                //case "brazil":
                //case "mexico":
                //    MHObj.WeatherForecastHandler(e.Result.Text);
                //    break;
                //////////////////////////////////////////////////////////////////////////////////////////
                /// <summary>
                /// news
                /// </summary>
                /// <returns></returns>
                /// 
                case "open News":
                    LoadGrammar(Modules.News, Grammars.NewsGrammar);
                    MHObj.OpenModule(Modules.News);
                    break;

                case "close News":
                    MHObj.CloseModule(Modules.News);
                    UnLoadGrammar(Modules.News);
                    break;
                case "Business News":
                case "Entertainment News":
                case "General News":
                case "Health News":
                case "Science News":
                case "Sports News":
                case "Technology News":
                    MHObj.NewsHandler(e.Result.Text);                    
                    break;

                //////////////////////////////////////////////////////////////////////////////////////////
                /// <summary>
                /// Alarm & Remainder
                /// </summary>
                /// <returns></returns>
                /// 

                case "set alarm":
                    remainder_grid.Visibility = Visibility.Hidden;
                    alaram_grid.Visibility = Visibility.Visible;
                    break;

                case "set remainder":
                    remainder_grid.Visibility = Visibility.Visible;
                    alaram_grid.Visibility = Visibility.Hidden;
                    break;

                //////////////////////////////////////////////////////////////////////////////////////////
                /// <summary>
                /// PC information
                /// </summary>
                /// <returns></returns>
                /// 

                case "ram":
                case "mac address":
                case "machine name":
                case "username":
                case "check internet connection":
                case "tell me your processor information":
                case "good morning":
                case "good night":
                case "good evening":
                case "what is the time":
                case "hello":
                case "todays date":
                case "battery status":
                case "who are you":
                case "how are you":
                    PcInfo.PcInformation p = new Gideon.PcInfo.PcInformation();
                    PcInfo.Information i = new PcInfo.Information();
                    p.Handler(e.Result.Text, i);
                    PcInfoGrid.DataContext = i;

                    break;


                //////////////////////////////////////////////////////////////////////////////////////////
                /// <summary>
                /// Gallery
                /// </summary>
                /// <returns></returns>
                /// 
                case "My Gallery":
                    MHObj.OpenModule(Modules.Gallery);
                    break;
                case "close My Gallery":
                    MHObj.CloseModule(Modules.Gallery);
                    break;

                case "Show Command List":
                    ShowCmdList(true);
                    break;

                case "Hide Command List":
                    ShowCmdList(false);
                    break;

                case "open game":
                    Process.Start(@"C:\Users\Harshal\Desktop\Minesweeper\Minesweeper\bin\Debug\Minesweeper.exe");
                    break;
                case "take screenshot":
                    //SynObj.SpeakAsync("Taking the screenshot");
                    //try
                    //{

                    //    System.Windows.Forms.SendKeys.Send("{PRTSC}");
                    //    System.Drawing.Image img = System.Windows.Forms.Clipboard.GetImage();
                    //    string path = @"C:\Users\Harshal\Desktop\My_Personal_Assistent\screenshots\" + "Temp" + DateTime.Now.Millisecond + ".jpg";
                    //    img.Save(path);
                    //}
                    //catch (Exception e1)
                    //{
                    //    System.Windows.Forms.MessageBox.Show(e1.ToString());
                    //}
                    break;

            }
        }
        void setBackgrounds()
        {
            // ImageBehavior.SetAnimatedSource(gideon_background, (ImageSource)new ImageSourceConverter().ConvertFromString(getBackground()));
            //    remainder_grid.Background = new ImageBrush(new BitmapImage(new Uri(robj.getBackground())));
            dateButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));
            monthButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));
            yearButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));

            hourButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));
            minuteButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));
            secondButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));
            meridateButtonUp.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/up_arrow.png")));

            dateButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));
            monthButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));
            yearButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));

            hourButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));
            minuteButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));
            secondButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));
            meridateButtonDown.Background = new ImageBrush(new BitmapImage(new Uri(Environment.CurrentDirectory + "/images/down_arrow.png")));


            //Next.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Next)) };
            //Previous.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Prev)) };
            //PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Play)) };
            WebAccess WObj = new WebAccess();
            WObj.google = WebAccessPath.GooglePath;
            WObj.youtube = WebAccessPath.YoutubePath;
            WObj.gmail = WebAccessPath.GmailPath;
            WObj.drive = WebAccessPath.DrivePath;
            WObj.github = WebAccessPath.GithubPath;
            WObj.facebook = WebAccessPath.FacebookPath;
            WObj.mic = WebAccessPath.MicPath;
            WObj.flash = WebAccessPath.FlashPath;
            WObj.instagram = WebAccessPath.InstaPath;

            cmd_btns_grid.DataContext = WObj;
        }
        public void showTime(object obj, EventArgs e)
        {
            int hr = DateTime.Now.Hour % 12;
            int min = DateTime.Now.Minute;
            int sec = DateTime.Now.Second;

            if (hr < 10)
                clock.Content = "0" + hr;
            else
                clock.Content = hr.ToString();

            if (min < 10)
                clock.Content += ":0" + min;
            else
                clock.Content += ":" + min.ToString();

            if (sec < 10)
                clock.Content += ":0" + sec;
            else
                clock.Content += ":" + sec.ToString();

            if (Convert.ToInt32(DateTime.Now.Hour) > 12)
                clock.Content += "  PM";
            else
                clock.Content += "  AM";

            if (sec % 5 == 0)
            {
                Gallery.Image i = new Gallery.Image();
                i.ImageName = new BitmapImage(new Uri(GalleryObj.getImage()));              
                GalleryButton.DataContext = i;
            }
            

            if (remainderTime == 10 && flag == false)
            {   
                for(int  i=0;i<2;i++)
                    SynObj.SpeakAsync("hey " + Environment.UserName + ", today is  " + RemainderObj.Check());

                flag = true;
            }


            if (remainderTime % 60 == 0)
            {
                MQuotes mobj = new MQuotes();

                mobj.quote = quotes[quotesCount%5];
                QuotesGrid.DataContext = mobj;
                quotesCount++;
            }
            remainderTime++;

        }
        private void Remainder_AcionListener(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button btn = (System.Windows.Controls.Button)sender;

            try
            {
                switch (btn.Uid.ToString())
                {
                    case "dateButtonUp":
                        textboxDate.Text = RemainderObj.incrementDate();
                        break;

                    case "monthButtonUp":
                        textboxMonth.Text = RemainderObj.incrementMonth();
                        break;

                    case "yearButtonUp":
                        textboxYear.Text = RemainderObj.incrementYear();
                        break;

                    case "dateButtonDown":
                        textboxDate.Text = RemainderObj.decrementDate();
                        break;

                    case "monthButtonDown":
                        textboxMonth.Text = RemainderObj.decrementMonth();
                        break;

                    case "yearButtonDown":
                        textboxYear.Text = RemainderObj.decrementYear();
                        break;

                    case "SET":
                        if (RemainderObj.validateDate())
                        {
                            MessageBox.Show("Remainder set");
                            //remainder_grid.Visibility = Visibility.Hidden;
                            RemainderUI.remainderlist.Add(RemainderObj.month[RemainderObj.index] + " " + RemainderObj.date + " " + remainderNote.Text);
                        }
                        break;

                    case "SetAlarm":

                        if (alaramSubmit.Content.Equals("SET"))
                        {
                            int result = aobj.validate();
                            if (result == 1)
                            {
                                //alaram_grid.Visibility = Visibility.Hidden;
                                SynObj.SpeakAsync("Alarm is set");
                                aobj.alarmtime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, aobj.hour, aobj.minute, aobj.second);
                                alaramSubmit.Content = "STOP";
                                dispatcherTimer.Start();
                            }
                            else
                            {
                                SynObj.SpeakAsync("Alarm time is wrong please provide correct time");
                                AlaramNote.Text = result.ToString();
                            }
                        }
                        else if (alaramSubmit.Content.Equals("STOP"))
                        {
                            //alaram_grid.Visibility = Visibility.Hidden;
                            alaramSubmit.Content = "SET";

                            if (AlaramNote.Text.Length == 0)
                                aobj.tone.Stop();
                        }

                        break;

                    case "hourButtonUp":
                        textboxHour.Text = aobj.IncrementHour();
                        break;

                    case "hourButtonDown":
                        textboxHour.Text = aobj.DecrementHour();
                        break;

                    case "minuteButtonUp":
                        textboxMinute.Text = aobj.IncrementMinute();
                        break;

                    case "minuteButtonDown":
                        textboxMinute.Text = aobj.DecrementMinute();
                        break;

                    case "secondButtonUp":
                        textboxSecond.Text = aobj.IncrementSecond();
                        break;

                    case "secondButtonDown":
                        textboxSecond.Text = aobj.DecrementSecond();
                        break;

                    case "meridateButtonUp":
                        textboxMeridate.Text = aobj.toggleMeridate();
                        break;

                    case "meridateButtonDown":
                        textboxMeridate.Text = aobj.toggleMeridate();
                        break;

                    case "GalleryButton":
                        MHObj.OpenModule(Modules.Gallery);
                        break;

                    case "GoogleBtn":
                        Process.Start("https://www.google.com/");
                        break;

                    case "GmailBtn":
                        Process.Start("https://mail.google.com/");
                        break;

                    case "DrieBtn":
                        Process.Start("https://drive.google.com/drive");
                        break;

                    case "YoutubeBtn":
                        Process.Start("https://www.youtube.com/");
                        break;

                    case "FacebookBtn":
                        Process.Start("https://www.facebook.com/");
                        break;

                    case "GithubBtn":
                        Process.Start("https://github.com/");
                        break;
                    case "InstaBtn":
                        Process.Start("https://www.instagram.com/");
                        break;
                    case "MicBtn":

                        if (MicBtn.ToolTip.Equals("MicOn"))
                        {
                            SetMicBackground();
                            EngineObj.RecognizeAsync(RecognizeMode.Multiple);
                        }
                        else
                        {
                            SetMicBackground(false);
                            EngineObj.RecognizeAsyncStop();
                        }

                        break;

                }
            }
            catch(Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }
        private void Remainder_Textbox_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            switch (tb.Uid.ToString())
            {
                case "TextboxDate_GotFocus":
                    dateButtonUp.Visibility = Visibility.Visible;
                    dateButtonDown.Visibility = Visibility.Visible;
                    monthButtonDown.Visibility = Visibility.Hidden;
                    monthButtonUp.Visibility = Visibility.Hidden;
                    yearButtonDown.Visibility = Visibility.Hidden;
                    yearButtonUp.Visibility = Visibility.Hidden;
                    break;

                case "TextboxMonth_GotFocus":
                    dateButtonUp.Visibility = Visibility.Hidden;
                    dateButtonDown.Visibility = Visibility.Hidden;
                    monthButtonDown.Visibility = Visibility.Visible;
                    monthButtonUp.Visibility = Visibility.Visible;
                    yearButtonDown.Visibility = Visibility.Hidden;
                    yearButtonUp.Visibility = Visibility.Hidden;
                    break;

                case "TextboxYear_GotFocus":
                    dateButtonUp.Visibility = Visibility.Hidden;
                    dateButtonDown.Visibility = Visibility.Hidden;
                    monthButtonDown.Visibility = Visibility.Hidden;
                    monthButtonUp.Visibility = Visibility.Hidden;
                    yearButtonDown.Visibility = Visibility.Visible;
                    yearButtonUp.Visibility = Visibility.Visible;
                    break;
            }
        }
        private void WeatherUpdate()
        {
            Weather[] WeatherObj = new Weather[1];
            WeatherObj[0] = new Weather();
            Weatherlb.ItemsSource = WeatherObj;
           
        }
        private void NewsUpdate()
        {
            GideonNews[] NewsObj = new GideonNews[1]; 
            NewsObj[0] = new GideonNews();
            
            Newslb.ItemsSource = NewsObj;

        }
        private void ListBoxListener(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;

            switch (lb.Uid.ToString())
            {
                case "Weatherlb":
                    Weather Wobj = (Weather)lb.SelectedItem;

                    if (Wobj == null)
                    {
                        return;
                    }

                    lb.SelectedItem = null;
                    LoadGrammar(Modules.WeatherForecast, Grammars.WeatherForecastGrammar);
                    MHObj.OpenModule(Modules.WeatherForecast);

                    break;

                case "Newslb":
                    GideonNews Gobj = (GideonNews)lb.SelectedItem;
                    if (Gobj == null)
                    {
                        return;
                    }
                    lb.SelectedItem = null;
                    LoadGrammar(Modules.News, Grammars.NewsGrammar);
                    MHObj.OpenModule(Modules.News);

                    break;

            }
           
        }
        private void MediaActionListener(object sender, RoutedEventArgs e)
        {
        //    Button btn = (Button)sender;

        //    if (!MHObj.IsRunning(Modules.MediaPlayer))
        //    {
        //        LoadGrammar(Modules.MediaPlayer, Grammars.MediaPlayerGrammar);
        //        MHObj.OpenModule(Modules.MediaPlayer);
        //    }

        //    switch (btn.Uid)
        //    {
        //        case "Play":
        //            MHObj.MediaPlayerHandler("play");
        //            if (PlayOrPause.ToolTip.Equals("Play"))
        //            {
        //                MHObj.MediaPlayerHandler("pause");
        //                PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Pause)) };
        //                PlayOrPause.ToolTip = "Pause";
        //            }
        //            else
        //            {
        //                MHObj.MediaPlayerHandler("play");
        //                PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Play)) };
        //                PlayOrPause.ToolTip = "Play";
        //            }
        //            break;

        //        case "Prev":
        //            MHObj.MediaPlayerHandler("previous");
        //            break;

        //        case "Next":
        //            MHObj.MediaPlayerHandler("next");
        //            break;

        //    }


        }
        private void Window_Closed(object sender, EventArgs e)
        {
            RemainderUI.WriteIntoFile();
            MHObj = null;
            GC.SuppressFinalize(MHObj);
            GC.Collect();
            
        }
        private void ShowCmdList(bool flag)
        {
            if (flag)
            {
                cmd_list_grid.Visibility = Visibility.Visible;
                btn_grid.Visibility = Visibility.Hidden;
                ListBox lobj = new ListBox();

                lobj.Items.Add(Grammars.gideonGrammar);
                lobj.Items.Add(Grammars.mediaPlayerGrammar);
                lobj.Items.Add(Grammars.newsGrammar);
                lobj.Items.Add(Grammars.pcinfoGrammar);

                string str = "";

                foreach (string[] str1 in lobj.Items)
                {
                    foreach (string s in str1)
                    {
                        str += s;
                        str += "\n";
                    }
                    str += "\n";
                }

                cmdlist.Text = str;
                return;
            }
            cmd_list_grid.Visibility = Visibility.Hidden;
            btn_grid.Visibility = Visibility.Visible;
        }
        private void SetMicBackground(bool flag = true)
        {
            WebAccess WObj = new WebAccess();

            if (flag)
            {
                WObj.mic = WebAccessPath.MicPath;
                MicBtn.ToolTip = "MicOff";
            }
            else
            {
                WObj.mic = WebAccessPath.MicOffPath;
                MicBtn.ToolTip = "MicOn";
                
            }

            WObj.google = WebAccessPath.GooglePath;
            WObj.youtube = WebAccessPath.YoutubePath;
            WObj.gmail = WebAccessPath.GmailPath;
            WObj.drive = WebAccessPath.DrivePath;
            WObj.github = WebAccessPath.GithubPath;
            WObj.facebook = WebAccessPath.FacebookPath;
            WObj.flash = WebAccessPath.FlashPath;
            WObj.instagram = WebAccessPath.InstaPath;

            cmd_btns_grid.DataContext = WObj;
        }
    }
}
