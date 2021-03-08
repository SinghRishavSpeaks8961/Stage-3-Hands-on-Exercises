using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace WindowsServiceUsage
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer1 = null;

        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            timer1 = new Timer();
            timer1.Interval = 10000;
            timer1.Elapsed += new ElapsedEventHandler(timer1_tick);
            timer1.Enabled = true;
            WriteFile("Windows Service Started");
            
        }

        private void timer1_tick(object sender, ElapsedEventArgs e)
        {
            WriteFile("Custom activity started at " + DateTime.Now);
        }

        protected override void OnStop()
        {
            timer1.Enabled = false;
            WriteFile("Windows Service Stopped");
        }

        public static void WriteFile(string message)
        {
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("E:\\Source\\WindowsServiceUsage\\WindowsServiceUsage\\bin\\Debug\\logfile.txt", true);
                sw.WriteLine(message);
                sw.Flush();
                sw.Close();
            }
            catch
            {

                
            }
        }
    }
}
