using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Gideon.Gallery
{
    /// <summary>
    /// Interaction logic for GalleryUI.xaml
    /// </summary>
    public partial class GalleryUserInterface : Window
    {
        public List<string> PhotoList;
        public Thread[] TObj;

        public Hashtable HTObj;

        public GalleryUserInterface()
        {
            InitializeComponent();
            PhotoList = new List<string>();
            SearchInAllDrives("*.*");
            HTObj = FindThumbnails();
            Update();

        }
        public async void UpdateImageList(string key)
        {
            try
            {

                await Task.Run(() =>
                {
                    Application.Current.Dispatcher.Invoke(new Action(() =>
                    {
                        ImageInfo[] IObj = new ImageInfo[(HTObj[key] as List<string>).Count];

                        int i = 0;
                        foreach (string s in HTObj[key] as List<string>)
                        {
                            string[] str = s.Split('\\');

                            IObj[i] = new ImageInfo
                            {
                                ImageData = LoadImage(s),
                                Title = str[str.Length - 1],
                                Path = s

                            };
                            i++;
                        }

                        foreach (ImageInfo img in IObj)
                        {
                            ImageList.Items.Add(img);
                        }



                    }));


                });
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }

        }
        private void ListBoxListener(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = (ListBox)sender;

            try
            {
                switch (lb.Uid)
                {
                    case "Outer_List":
                        ImageInfo iobj1 = (ImageInfo)lb.SelectedItem;
                        lb = null;
                        ImageList.Items.Clear();
                        UpdateImageList(iobj1.Title);

                        break;
                    case "Internal_List":
                        ImageInfo iobj2 = (ImageInfo)lb.SelectedItem;
                        lb = null;
                        imgsrc.Source = null;
                        ShowImgScreen(iobj2.Path);
                        break;
                }
            }
            catch (Exception)
            {

            }
        }
        public void ShowImgScreen(string img)
        {
            ImgScreen.Visibility = Visibility.Visible;
            imgsrc.Source = LoadImage(img, false);
        }
        public void Update()
        {

            ImageInfo[] IObj = new ImageInfo[HTObj.Count];


            int i = 0;
            foreach (DictionaryEntry h in HTObj)
            {
                IObj[i] = new ImageInfo
                {
                    ImageData = LoadImage(((List<string>)HTObj[h.Key]).First()),
                    Title = h.Key.ToString(),

                };

                i++;
            }

            Thumbnails.ItemsSource = IObj;

        }
        public BitmapImage LoadImage(string url, bool flag = true)
        {
            BitmapImage bi = null;
            try
            {

                bi = new BitmapImage();
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.UriSource = new Uri(url);
                if (flag)
                {
                    bi.DecodePixelWidth = 110;
                }
                bi.EndInit();
            }
            catch (Exception e)
            {

            }
            return bi;
        }
        public void SearchMediaFiles(string path, string pattern)
        {
            string[] dirs = null;
            string[] files = null;

            try
            {

                dirs = Directory.GetDirectories(path);
                foreach (string d in dirs)
                {
                    SearchMediaFiles(d, pattern);
                }

                files = Directory.GetFiles(path, pattern).Where(s => s.EndsWith(".jpg") || s.EndsWith(".jpeg") || s.EndsWith(".png")).ToArray();

                foreach (string file in files)
                {
                    PhotoList.Add(file);
                }

            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (IOException)
            {

            }
            catch (Exception)
            {
                //throw;
            }

        }
        public void SearchInAllDrives(string pattern)
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            TObj = new Thread[allDrives.Length];

            int i = 0;

            foreach (DriveInfo drive in allDrives)
            {
                if (!drive.RootDirectory.ToString().Equals(@"C:\") && !drive.RootDirectory.ToString().Equals(@"F:\"))
                {
                    if (drive.DriveType.ToString().Equals("Fixed"))
                    {
                        TObj[i] = new Thread(() => { SearchMediaFiles(drive.RootDirectory.ToString(), pattern); });
                        TObj[i].Start();
                        i++;
                    }
                }

            }
        }
        public Hashtable FindThumbnails()
        {
            List<string> ThumbnailList;
            Hashtable Thumbnailtable = new Hashtable();

            try
            {
                foreach (Thread thread in TObj)
                {
                    thread.Join();
                }
            }
            catch (NullReferenceException)
            {

            }
            catch (Exception)
            {

            }

            foreach (string photo in PhotoList)
            {
                string[] str = photo.Split('\\');
                string key = str[str.Length - 2];

                if (Thumbnailtable.ContainsKey(key))
                {
                    ThumbnailList = (List<string>)Thumbnailtable[key];
                    ThumbnailList.Add(photo);
                }
                else
                {
                    ThumbnailList = new List<string>();
                    ThumbnailList.Add(photo);
                    Thumbnailtable.Add(key, ThumbnailList);

                }
            }
            return Thumbnailtable;
        }


        private void KeyboardListener(object sender, KeyEventArgs e)
        {
            if (e.Key.ToString().Equals("Escape"))
            {
                ImgScreen.Visibility = Visibility.Hidden;
            }
        }

    }
}
