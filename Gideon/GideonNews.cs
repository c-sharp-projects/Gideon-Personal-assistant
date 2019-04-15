using NewsAPI;
using NewsAPI.Constants;
using NewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Gideon
{
    class GideonNews
    {
        const string ApiKey = "fe1b8a7f7c4841f6aa2a8aec1239f816";
        public NewsApiClient news;

        public BitmapImage Image { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string PublishedAt { get; set; }
        public string Url { get; set; }
        public string UrlToImage { get; set; }

        public GideonNews()
        {
            LoadIcon();
        }

        public void LoadIcon()
        {
            Image = LoadImage(NewsPath.NewsIcon);         
        }
        

        public BitmapImage LoadImage(string url)
        {
            BitmapImage bi = null;
            try
            {
                if (url == null)
                {
                    url = NewsPath.Nopreviewimg;
                }

                bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(url);
                bi.EndInit();
            }
            catch (Exception e)
            {
                url = NewsPath.Nopreviewimg;
                bi = new BitmapImage();
                bi.BeginInit();
                bi.UriSource = new Uri(url);
                bi.EndInit();
            }
            return bi;
        }

    }


}
