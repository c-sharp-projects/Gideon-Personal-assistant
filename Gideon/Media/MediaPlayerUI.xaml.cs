using Gideon.Codes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Gideon.Media
{
    /// <summary>
    /// Interaction logic for MediaPlayerUI.xaml
    /// </summary>
    public partial class MediaPlayerUI : Window
    {
        DispatcherTimer timer;
        bool IsSeeked;
        bool IsPlay;
        bool IsAList;
        bool IsVList;
        MediaPlayer MObj;
        MediaCodes Indicator;
        string songname = String.Empty;
        public MediaPlayerUI()
        {
            InitializeComponent();
            
            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            timer.Tick += Seek_Timer;
            timer.Start();

            LoadIcon();

            IsSeeked = false;
            IsPlay = false;
            IsAList = false;
            IsVList = false;


            MObj = new MediaPlayer();
            Indicator = MediaCodes.PlayAudio;
            songname = MObj.Audios[MObj.AudPos];
            MyMediaElement.Source = new Uri(songname);


        }
        private void Seek_Timer(object sender, EventArgs e)
        {
            if ((MyMediaElement.Source != null) && (MyMediaElement.NaturalDuration.HasTimeSpan) && (!IsSeeked))
            {
                Seeker.Minimum = 0;
                Seeker.Maximum = MyMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                Seeker.Value = MyMediaElement.Position.TotalSeconds;
            }
        }
        private void Seek_Drag_Started(object sender, DragStartedEventArgs e)
        {
            IsSeeked = true;
        }
        private void Seek_Drag_Completed(object sender, DragCompletedEventArgs e)
        {
            IsSeeked = false;
            MyMediaElement.Position = TimeSpan.FromSeconds(Seeker.Value);
        }
        private void Seek_Value_Changed(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayTime.Text = TimeSpan.FromSeconds(Seeker.Value).ToString(@"hh\:mm\:ss");
        }
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            MyMediaElement.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }
        private void LoadIcon()
        {
            try
            {
                Next.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Next)) };
                Previous.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Prev)) };
                PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Play)) };
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void ListDoubleClick(object sender, EventArgs e)
        {
            ListBox list = (ListBox)sender;

            if (IsAList)
            {
                Indicator = MediaCodes.PlayAudio;
                MObj.AudPos = list.SelectedIndex;
            }
            else
            {
                Indicator = MediaCodes.PlayVideo;
                MObj.VidPos = list.SelectedIndex;
            }

            PlaySong(Indicator,new Song());
        }
        private void ActionListener(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;

            switch (btn.Uid)
            {
                case "Play":
                    if (IsPlay)
                    {
                        PauseSong(new Song());
                    }
                    else
                    {
                        PlaySong(MediaCodes.Play, new Song());
                    }
                    break;

                case "Prev":
                    PreviousSong(new Song());
                    break;

                case "Next":
                    NextSong( new Song());
                    break;

                case "AudioList":
                    if (!IsAList)
                    {
                        IsAList = true;
                        IsVList = false;
                        ShowList(MediaCodes.AudioList);
                        return;
                    }
                    PlayList.Items.Clear();
                    PlayList.Visibility = Visibility.Hidden;
                    IsAList = false;
                    break;

                case "VideoList":
                    if (!IsVList)
                    {
                        IsVList = true;
                        IsAList = false;
                        ShowList(MediaCodes.VideoList);
                        return;
                    }
                    PlayList.Items.Clear();
                    PlayList.Visibility = Visibility.Hidden;
                    IsVList = false;
                    break;
            }

        }
        public void PlaySong(MediaCodes Indicator , Song s)
        {
            if (!File.Exists(MediaPath.AudioFile) && !File.Exists(MediaPath.VideoFile))
            {
                MObj.LoadAllSongs();
            }
            if (MyMediaElement.IsMuted)
            {
                GideonBase.SynObj.SpeakAsync("Volume is mute, please Increase the volume!");
            }

            switch (Indicator)
            {
                case MediaCodes.PlayAudio:
                    this.Indicator = Indicator;
                   // this.Visibility = Visibility.Hidden;
                    if (!File.Exists(MObj.Audios[MObj.AudPos]))
                    {
                        NextSong(s);
                        return;
                    }
                    songname = MObj.Audios[MObj.AudPos];
                   
                    GideonBase.SynObj.SpeakAsync("Playing Song!");
                    MyMediaElement.Source = new Uri(songname);

                    break;
                case MediaCodes.PlayVideo:
                    this.Indicator = Indicator;
                    //this.Visibility = Visibility.Visible;
                    if (!File.Exists(MObj.Videos[MObj.VidPos]))
                    {
                        NextSong(s);
                        return;
                    }

                    songname = MObj.Videos[MObj.VidPos];
                    GideonBase.SynObj.SpeakAsync("Playing Video!");
                    MyMediaElement.Source = new Uri(songname);
                    break;
                case MediaCodes.Play:

                    if (!File.Exists(MObj.Audios[MObj.AudPos]))
                    {
                        NextSong(s);
                        return;
                    }
                    if (!File.Exists(MObj.Videos[MObj.VidPos]))
                    {
                        NextSong(s);
                        return;
                    }
                    
                    break;
            }

            IsPlay = true;
            PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Pause)) };
            PlayOrPause.ToolTip = "Play";           
            s.SongName = songname;
            MyMediaElement.Play();
        }
        public void PauseSong(Song s)
        {
            IsPlay = false;
            PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Play)) };
            PlayOrPause.ToolTip = "Pause";
            MyMediaElement.Pause();

            if (Indicator == MediaCodes.PlayAudio)
            {
                GideonBase.SynObj.SpeakAsync("Song Paused!");
            }
            else if(Indicator == MediaCodes.PlayVideo)
            {
                GideonBase.SynObj.SpeakAsync("Video Paused!");
            }
            s.SongName = songname;
        }
        public void StopSong(Song s)
        {
            MyMediaElement.Stop();
            IsPlay = false;
            PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Play)) };
            PlayOrPause.ToolTip = "Pause";
            GideonBase.SynObj.SpeakAsync("MediaPlayer has been stopped!");
            s.SongName = songname;
        }
        public void NextSong(Song s)
        {
            //string songname = String.Empty;

            if (!File.Exists(MediaPath.AudioFile) && !File.Exists(MediaPath.VideoFile))
            {
                MObj.LoadAllSongs();
            }
            if (MyMediaElement.IsMuted)
            {
                GideonBase.SynObj.SpeakAsync("Volume is mute, please Increase the volume!");
            }
            switch (Indicator)
            {
                case MediaCodes.PlayAudio:

                    ++MObj.AudPos;

                    if (MObj.AudPos > MObj.Audios.Length - 1)
                    {
                        MObj.AudPos = 0;
                    }
                    if (!File.Exists(MObj.Audios[MObj.AudPos]))
                    {
                        NextSong(s);
                        return;
                    }

                    songname = MObj.Audios[MObj.AudPos];
                    GideonBase.SynObj.SpeakAsync("Playing Next Song!");
                    MyMediaElement.Source = new Uri(songname);
                    break;
                case MediaCodes.PlayVideo:

                    ++MObj.VidPos;

                    if (MObj.VidPos > MObj.Videos.Length - 1)
                    {
                        MObj.VidPos = 0;
                    }
                    if (!File.Exists(MObj.Videos[MObj.VidPos]))
                    {
                        NextSong(s);
                        return;
                    }

                    songname = MObj.Videos[MObj.VidPos];
                    
                    GideonBase.SynObj.SpeakAsync("Playing Next Video!");
                    MyMediaElement.Source = new Uri(songname);
                    break;

            }
            IsPlay = true;
            PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Pause)) };
            PlayOrPause.ToolTip = "Play";          
            s.SongName = songname;
            MyMediaElement.Play();
        }
        public void PreviousSong(Song s)
        {
         
            if ((!File.Exists(MediaPath.AudioFile)) && (!File.Exists(MediaPath.VideoFile)))
            {
                MObj.LoadAllSongs();
            }
            if (MyMediaElement.IsMuted)
            {
                GideonBase.SynObj.SpeakAsync("Volume is mute, please Increase the volume!");
            }
            switch (Indicator)
            {
                case MediaCodes.PlayAudio:
                    --MObj.AudPos;

                    if (MObj.AudPos < 0)
                    {
                        MObj.AudPos = MObj.Audios.Length - 1;
                    }
                    if (!File.Exists(MObj.Audios[MObj.AudPos]))
                    {
                        PreviousSong(s);
                        return;
                    }

                    songname = MObj.Audios[MObj.AudPos];
                    
                    GideonBase.SynObj.SpeakAsync("Playing Previous Song!");
                    MyMediaElement.Source = new Uri(songname);
                    break;
                case MediaCodes.PlayVideo:
                    --MObj.VidPos;

                    if (MObj.VidPos < 0)
                    {
                        MObj.VidPos = MObj.Videos.Length - 1;
                    }
                    if (!File.Exists(MObj.Videos[MObj.VidPos]))
                    {
                        PreviousSong(s);
                        return;
                    }
                    songname = MObj.Videos[MObj.VidPos];
                    
                    GideonBase.SynObj.SpeakAsync("Playing Previous Video!");
                    MyMediaElement.Source = new Uri(songname);
                    break;
            }
            IsPlay = true;
            PlayOrPause.Content = new Image { Source = new BitmapImage(new Uri(MediaPath.Pause)) };
            PlayOrPause.ToolTip = "Play";
            
            s.SongName = songname;
            MyMediaElement.Play();
        }
        public void ShowList(MediaCodes Indicator)
        {
            PlayList.Items.Clear();
            PlayList.Visibility = Visibility.Visible;

            switch (Indicator)
            {
                case MediaCodes.AudioList:

                    foreach (string s in MObj.Audios)
                    {
                        PlayList.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
                    }

                    break;
                case MediaCodes.VideoList:

                    foreach (string s in MObj.Videos)
                    {
                        PlayList.Items.Add(s.Substring(s.LastIndexOf('\\') + 1));
                    }

                    break;
            }
        }
        public void AdjustVolume(MediaCodes indicator,Song s)
        {
            MyMediaElement.IsMuted = false;
            switch (indicator)
            {
                case MediaCodes.DecreaseVolume: //decrease volume
                    if (MyMediaElement.Volume > 0)
                    {
                        MyMediaElement.Volume -= 0.1;
                        GideonBase.SynObj.SpeakAsync("Volume Decreased!");
                        return;
                    }

                    break;

                case MediaCodes.IncreaseVolume: //increase volume
                    if (MyMediaElement.Volume < 1.0)
                    {
                        MyMediaElement.Volume += 0.1;
                        GideonBase.SynObj.SpeakAsync("Volume Increased!");
                    }
                    break;

                case MediaCodes.Mute: //mute volume
                    MyMediaElement.Volume = 0.0;
                    MyMediaElement.IsMuted = true;
                    GideonBase.SynObj.SpeakAsync("Volume mute!");
                    break;

                case MediaCodes.FullVolume: //full volume
                    MyMediaElement.Volume = 1.0;
                    GideonBase.SynObj.SpeakAsync("Volume is full!");
                    break;

            }
            s.SongName = songname;
        }
        public void SetWindow(MediaCodes Indicator,Song s)
        {
            switch (Indicator)
            {
                case MediaCodes.Maximize:
                    if (WindowState == WindowState.Normal || WindowState == WindowState.Minimized)
                    {
                        WindowState = System.Windows.WindowState.Maximized;
                        GideonBase.SynObj.SpeakAsync("MediaPlayer Maximized!");
                    }
                    else
                    {
                        GideonBase.SynObj.SpeakAsync("MediaPlayer is already Maximized!");
                    }

                    break;

                case MediaCodes.Minimize:

                    if (WindowState == WindowState.Maximized || WindowState == WindowState.Normal)
                    {
                        WindowState = System.Windows.WindowState.Minimized;
                        GideonBase.SynObj.SpeakAsync("MediaPlayer Minimized!");
                    }
                    else
                    {
                        GideonBase.SynObj.SpeakAsync("MediaPlayer is already Minimized!");
                    }
                    break;
            }
            s.SongName = songname;
        }
    }

    public class Song
    {
        public string Name;
        public string SongName
        {
            get
            {
                return Name.Substring(Name.LastIndexOf('\\')+1);
            }
            set
            {
                Name = value;
            }
        }
    }
}
