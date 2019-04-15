using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows;
using System.Net.NetworkInformation;
using Microsoft.Win32;

namespace Gideon.PcInfo
{
    class PcInformation
    {

        public ulong GetTotalMemoryInBytes()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }

        public void say(String h)
        {
            GideonBase.SynObj.SpeakAsync(h);
        }

        public string GetMacaddr()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            int count = 0;
            String str = null;

            foreach (char c in macAddresses)
            {

                if (count == 2)
                {
                    str += ":";
                    count = 0;
                }
                str += c;
                count++;
            }

            return str;
        }

        public static String GetProcessor()
        {
            RegistryKey processor_name = Registry.LocalMachine.OpenSubKey(@"Hardware\Description\System\CentralProcessor\0", RegistryKeyPermissionCheck.ReadSubTree);   //This registry entry contains entry for processor info.

            if (processor_name != null)
            {
                if (processor_name.GetValue("ProcessorNameString") != null)
                {
                    return processor_name.GetValue("ProcessorNameString").ToString();
                }

            }
            return null;
        }

        public void Handler(string str , Information i)
        {
            switch (str)
            {
                case "ram":
                   
                    double ra = Math.Round((GetTotalMemoryInBytes() / 1024f / 1024f / 1024f), 2);
                    i.info = ra.ToString() + " GB";
                    break;

                case "mac address":

                    i.info = GetMacaddr().ToString();
                    break;

                case "machine name":

                    i.info = Environment.MachineName;
                    break;

                case "username":
                    i.info = Environment.UserName;
                    break;

                case "check internet connection":
                    if (NetworkInterface.GetIsNetworkAvailable())
                    {
                        i.info = "You are Connected To Internet";                        
                    }
                    else
                    {
                        i.info = ":-( No Connection! :-(";
                    }
                    break;

                case "tell me your processor information":
                    if (System.Environment.Is64BitOperatingSystem)
                    {
                        i.info = "Your Machine has a 64 bit Operating System ";                       
                    }
                    else
                    {
                        i.info = "Your Machine has a 32 bit Operating System ";                       
                    }

                    i.info += "and uses ";
                    i.info += GetProcessor();
                  
                    break;

                case "good morning":
                    i.info = "Good morning, I hope you slept well.";
                    break;

                case "good night":
                    i.info = "I've always wondered what sleep would feel like, I suppose I will never know. Goodnight.";
                    break;

                case "good evening":
                    i.info = "Good evening.";
                    break;

                case "what is the time":
                    i.info = DateTime.Now.ToShortTimeString();
                    break;

                case "todays date":
                    i.info = DateTime.Now.ToShortDateString();
                    break;

                case "hello":
                    i.info = "Hii there...!";
                    break;

                case "battery status":

                    System.Management.ManagementClass manage = new System.Management.ManagementClass("win32_Battery");
                   

                    var allbattries = manage.GetInstances();

                    foreach (var battery in allbattries)
                    {
                        int estimatedbattery = Convert.ToInt32(battery["EstimatedChargeRemaining"]);

                        if (estimatedbattery == 100)
                        {
                            i.info += "\n Battery is fully charged";
                        }
                        else
                        {
                            i.info += "\n The estimated charging is , " + estimatedbattery + " percent" ;
                        }
                    }
                    break;

                case "who are you":
                    i.info = "Im Gideon , your personal assistant";
                    break;

                case "how are you":
                    i.info = "Im fine..";
                    break;
            }
            say(i.info);
        }

    }

    class Information
    {
        public string info
        {
            get;
            set;
        }
    }
}
