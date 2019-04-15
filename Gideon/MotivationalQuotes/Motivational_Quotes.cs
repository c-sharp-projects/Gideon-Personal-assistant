using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Gideon.MotivationalQuotes
{
    class Motivational_Quotes
    {
        private const string URL = "http://motivationping.com/quotes/";



        public static String[] FetchQuotes()
        {   
            WebClient web = new WebClient();
            String html = web.DownloadString(URL);

            string data;
            string[] array = new string[5];

            char[] arr = new char[] { '\n' };
            data = html.Substring(html.LastIndexOf("<p>" + 1 + "."));
            array = data.Split(arr, 6);

            for (int i = 0; i < 5; i++)
            {
                array[i] = array[i].Remove(0, 5);
                array[i] = array[i].Remove(array[i].LastIndexOf('<'));
            }

            return array;
        }
    }

    class MQuotes
    {
        public string quote;

        public string Quotes
        {
            get
            {
                return quote;
            }
           
        }

        
    }

}
