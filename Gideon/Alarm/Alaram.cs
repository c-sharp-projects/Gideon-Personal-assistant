using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Gideon.Alarm
{
    class Alaram
    {
        public int hour;
        public int minute;
        public int second;
        public int meridate;
        public string note;
        public DateTime alarmtime;
        public SoundPlayer tone;

        public Alaram()
        {
            hour = DateTime.Now.Hour%12;
            minute = DateTime.Now.Minute;
            second = DateTime.Now.Second;
        }

        public string IncrementHour()
        {
            if (hour >= 12)
                hour = 1;
            else
                hour++;
            return hour.ToString();
        }

        public string IncrementMinute()
        {
            if (minute >= 59)
                minute = 1;
            else
                minute++;
            return minute.ToString();
        }

        public string IncrementSecond()
        {
            if (second >= 59)
                second = 1;
            else
                second++;
            return second.ToString();
        }

        public string DecrementHour()
        {
            if (hour == 0)
                hour = 12;
            else
                hour--;
            return hour.ToString();
        }

        public string DecrementMinute()
        {
            if (minute == 1)
                minute = 59;
            else
                minute--;
            return minute.ToString();
        }

        public string DecrementSecond()
        {
            if (second == 1)
                second = 59;
            else
                second--;
            return second.ToString();
        }


        public string toggleMeridate()
        {
            meridate++;
            return meridate % 2 == 0 ? "AM" : "PM";
        }


        public int validate()
        {
            /*DateTime time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second); //time set from UI
            DateTime currenttime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            return DateTime.Compare(time,currenttime);*/


            int Hour = DateTime.Now.Hour % 12;
            int Minute = DateTime.Now.Minute;
            int Second = DateTime.Now.Second;

            if (hour < Hour)
                return -1;

            if ((hour == Hour) && (minute < Minute))
                return -1;

            if ((hour == Hour) && (minute == Minute) && (second <= Second))
                return -1;

            return 1;
        }
    }
}
