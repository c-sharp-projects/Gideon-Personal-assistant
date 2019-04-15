using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gideon.Remainder
{
    //   public class RemainderUI
    //   {
    //       //Visibility="Hidden"
    //       public string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
    //       public int index;
    //       public int date;
    //       public int year;

    //       public RemainderUI()
    //       {
    //           index = DateTime.Now.Month - 1;
    //           date = DateTime.Now.Date.Day;
    //           year = DateTime.Now.Year;

    //       }
    //       public string getBackground()
    //       {
    //           return AppDomain.CurrentDomain.BaseDirectory + @"\images\5.jpg";
    //       }

    //       public string incrementDate()
    //       {
    //           if (date >= DateTime.DaysInMonth(year, index + 1))
    //               date = 1;
    //           else
    //               date++;

    //           return date.ToString();
    //       }

    //       public string decrementDate()
    //       {
    //           if (date == 1)
    //               date = DateTime.DaysInMonth(year, index + 1);
    //           else
    //               date--;
    //           return date.ToString();
    //       }


    //       public string incrementMonth()
    //       {
    //           index++;
    //           if (index == month.Length)
    //               index = 0;
    //           return month[index];
    //       }

    //       public string decrementMonth()
    //       {
    //           index--;
    //           if (index == -1)
    //               index = month.Length - 1;
    //           return month[index];
    //       }

    //       public string incrementYear()
    //       {
    //           year++;
    //           return year.ToString();
    //       }

    //       public string decrementYear()
    //       {
    //           year--;
    //           return year.ToString();
    //       }
    //       /*A leap year is exactly divisible by 4 except for century years (years ending with 00).
    //* The century year is a leap year only if it is perfectly divisible by 400.*/

    //       public Boolean leapYear()
    //       {
    //           Boolean flag = true;

    //           if (year % 4 == 0)
    //           {
    //               if (year % 100 == 0)
    //               {
    //                   if (year % 400 == 0)
    //                       flag = true;
    //                   else
    //                       flag = false;
    //               }
    //               else
    //                   flag = true;
    //           }
    //           else
    //               flag = false;

    //           return flag;
    //       }

    //       public Boolean validateDate()
    //       {
    //           if (year < DateTime.Now.Year)
    //               return false;
    //           if (year == DateTime.Now.Year && (index < DateTime.Now.Month - 1))
    //               return false;
    //           if (year == DateTime.Now.Year && (index == DateTime.Now.Month - 1) && (date < DateTime.Now.Day))
    //               return false;

    //           return true;
    //       }
    //   }

    public class GFG : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (x == null || y == null)
            {
                return 0;
            }
            // "CompareTo()" method 
            return x.CompareTo(y);
        }
    }

    public class RemainderUI
    {
        public static List<string> remainderlist = new List<string>();

        public string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        public int index;
        public int date;
        public int year;

        public RemainderUI()
        {
            index = DateTime.Now.Month - 1;
            date = DateTime.Now.Date.Day;
            year = DateTime.Now.Year;


        }
        public string getBackground()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"\images\5.jpg";
        }

        public string incrementDate()
        {
            if (date >= DateTime.DaysInMonth(year, index + 1))
                date = 1;
            else
                date++;

            return date.ToString();
        }

        public string decrementDate()
        {
            if (date == 1)
                date = DateTime.DaysInMonth(year, index + 1);
            else
                date--;
            return date.ToString();
        }


        public string incrementMonth()
        {
            index++;
            if (index == month.Length)
                index = 0;
            return month[index];
        }

        public string decrementMonth()
        {
            index--;
            if (index == -1)
                index = month.Length - 1;
            return month[index];
        }

        public string incrementYear()
        {
            year++;
            return year.ToString();
        }

        public string decrementYear()
        {
            year--;
            return year.ToString();
        }
        /*A leap year is exactly divisible by 4 except for century years (years ending with 00).
 * The century year is a leap year only if it is perfectly divisible by 400.*/

        public Boolean leapYear()
        {
            Boolean flag = true;

            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                        flag = true;
                    else
                        flag = false;
                }
                else
                    flag = true;
            }
            else
                flag = false;

            return flag;
        }

        public Boolean validateDate()
        {
            if (year < DateTime.Now.Year)
                return false;
            if (year == DateTime.Now.Year && (index < DateTime.Now.Month - 1))
                return false;
            if (year == DateTime.Now.Year && (index == DateTime.Now.Month - 1) && (date < DateTime.Now.Day))
                return false;

            return true;
        }

        public static void WriteIntoFile()
        {
            GFG gg = new GFG();
            remainderlist.Sort(gg);

            FileStream fs = new FileStream("remainderList.txt", FileMode.OpenOrCreate | FileMode.Truncate, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            for (int i = 0; i < remainderlist.Count; i++)
            {
                sw.WriteLine(remainderlist[i]);
            }
            sw.Close();
            fs.Close();
        }

        public static void ReadFromFile()
        {
            string line;

            FileStream fs = new FileStream("remainderList.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);

            while ((line = sr.ReadLine()) != null)
            {
                remainderlist.Add(line);
            }
        }

        public string Check()
        {
            foreach (string str in remainderlist)
            {
                char[] arr = new char[] { ' ' };

                string[] info = str.Split(arr, 3);

                if (info[0] == month[DateTime.Now.Month - 1])
                {
                    if (Convert.ToInt32(info[1]) == DateTime.Now.Day)
                    {
                        //MessageBox.Show(info[2]);
                        /*                       var notification = new System.Windows.Forms.NotifyIcon()
                                               {
                                                   Visible = true,
                                                   Icon = System.Drawing.SystemIcons.Information,
                                                   // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                                                   // optional - BalloonTipTitle = "My Title",
                                                   BalloonTipText = info[2],
                                               };

                                               // Display for 5 seconds.
                                               notification.ShowBalloonTip(5000);

                                               // This will let the balloon close after it's 5 second timeout
                                               // for demonstration purposes. Comment this out to see what happens
                                               // when dispose is called while a balloon is still visible.
                                               Thread.Sleep(10000);

                                               // The notification should be disposed when you don't need it anymore,
                                               // but doing so will immediately close the balloon if it's visible.
                                               notification.Dispose();
                         */
                        return info[2];
                    }
                }
            }
            return "";
        }
    }
}
