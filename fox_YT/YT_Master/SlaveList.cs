﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;

namespace YT_Master
{
    public class SlaveList : Slave
    {
        private string url_error = @"https://www.youtube.com/watch?v=5BZLz21ZS_Y";    // initial - error
        private int    ms_to_sec = 1000;
        private string url_other;  
        private string url_my;       


        public SlaveList()
        {
            List<List<string>> url_list = get_url();
            watcher = new FirefoxWatcher();
            watcher.Navigate(url_error);
            watcher.ClickButton_ZgadzamSie();

            url_my = url_list[0][0];
            url_other = url_list[1][0];
        }
        public void Watch()
        {
            for (int i = 0; i < 100; i++)
            {
                Work();
            }
        }
        public void Work()
        {
            int time_my = getRandomNumberOfSeconds();
            int time_other = getRandomNumberOfSeconds();

            Console.WriteLine("Other_time: "+   (time_other/60).ToString()+" min");
            Console.WriteLine("My_time:    " +  (time_my/60).ToString()   +" min");

            Work_tmp(time_other, url_other);
            Work_tmp(time_my   , url_my);
        }
        public void Work_tmp(int time, string url)
        {
            watcher.Navigate(url);
            watcher.ClickButton_PlayVideo();
            Thread.Sleep(time * ms_to_sec);
        }


    }
}