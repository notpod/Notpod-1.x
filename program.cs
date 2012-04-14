using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Text;
using log4net.Config;

namespace Notpod
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(File.Exists("Resources\\logging.xml"))
                XmlConfigurator.Configure(new FileInfo("Resources\\logging.xml"));

            Application.EnableVisualStyles();
            MainForm form = new MainForm();
            Application.Run(form);            
        }
        
    }
}