using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Timers;
using WUApiLib;

namespace WindowsUpdateAgent
{
    public partial class WindowsUpdateAgent : ServiceBase
    {
        public static string logDirectory = @"C:/WUA/";
        public WindowsUpdateAgent()
        {
            InitializeComponent();
        }
        public static bool time_to_run()
        {
            List<string> run_time = new List<string>();
            run_time.Add("06");
            run_time.Add("12");
            string now = DateTime.Now.ToString("HH");
            foreach (string time in run_time)
            {
                if (now == time)
                    return true;
            }
            return false;
        }
        public static void main_processor()
        {
            if (time_to_run() == false)
                return;

            UpdateSession uSession = new UpdateSession();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            uSearcher.Online = true;
            ISearchResult sResult = uSearcher.Search("IsInstalled = 0");

            string serviceLogName = string.Concat(DateTime.Now.ToString("yyyy.MM.dd"), ".log");
            using (StreamWriter sw = new StreamWriter(string.Concat(logDirectory, serviceLogName), true))
            {
                foreach (IUpdate update in sResult.Updates)
                {
                    sw.WriteLine("[{0}] {1}", DateTime.Now.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'Z'"), update.Title);
                }
            }
        }
        public void OnTimer(object sender, ElapsedEventArgs args)
        {
            main_processor();
        }
        protected override void OnStart(string[] args)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 43200000; // 60000 milliseconds
            timer.Elapsed += new ElapsedEventHandler(this.OnTimer);
            timer.Start();

            if (!Directory.Exists(logDirectory))
            {
                System.IO.Directory.CreateDirectory(logDirectory);
            }

            Thread t = new Thread(() =>
            {
                main_processor();
            });
            t.Start();
        }

        protected override void OnStop()
        {
        }
    }
}
