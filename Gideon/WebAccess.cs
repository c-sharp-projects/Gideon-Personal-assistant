using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Gideon
{
    class WebAccess
    {
        public string google { get; set; }
        public string youtube { get; set; }
        public string drive { get; set; }
        public string github { get; set; }
        public string gmail { get; set; }
        public string facebook { get; set; }
        public string mic { get; set; }
        public string instagram { get; set; }
        public string flash { get; set; }



        public BitmapImage GoogleImg
        {
            get
            {
                return getImage(google);
            }
        }

        public BitmapImage MicImg
        {
            get
            {
                return getImage(mic);
            }
        }
        public BitmapImage YoutubeImg
        {
            get
            {
                return getImage(youtube);
            }
        }

        public BitmapImage DriveImg
        {
            get
            {
                return getImage(drive);
            }
        }

        public BitmapImage GihubImg
        {
            get
            {
                return getImage(github);
            }
        }

        public BitmapImage GmailImg
        {
            get
            {
                return getImage(gmail);
            }
        }
        public BitmapImage FacebookImg
        {
            get
            {
                return getImage(facebook);
            }
        }

        public BitmapImage InstaImg
        {
            get
            {
                return getImage(instagram);
            }
        }

        public BitmapImage FlashImg
        {
            get
            {
                return getImage(flash);
            }
        }

        private BitmapImage getImage(string str)
        {
            return new BitmapImage(new Uri(str));
        }

    }
}
