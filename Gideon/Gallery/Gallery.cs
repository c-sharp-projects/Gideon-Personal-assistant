using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Gideon.Gallery
{
    public class GalleryUI
    {
        public string[] paths;
        public int counter;
        public GalleryUI()
        {
            counter = 0;
            paths = Directory.GetFiles(Environment.CurrentDirectory + "/gallery", "*.jpg");
        }

        public string getImage()
        {
            counter++;
            return paths[counter % (paths.Length - 1)];
        }
    }

    public class Image
    {
        public BitmapImage ImageName
        {
            get;
            set;
        }
    }
}
