using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Notpod.Properties;
using Notpod.Configuration12;
using log4net;

namespace Notpod
{
    /// <summary>
    /// Contains methods for managing configuration.
    /// </summary>
    public class ConfigurationHelper
    {
        private static ILog l = LogManager.GetLogger(typeof(ConfigurationHelper));
        /// <summary>
        /// Move configuration from iTA to Notpod
        /// </summary>
        /// <returns></returns>
        public static bool MovePreNotpodConfiguration()
        {
            MessageBox.Show("It seems that you have recently installed me, or upgraded me from iTunes Agent - my previous name. "
                + "I need to configure myself for this new version.\n\nIf you "
                + "have existing configuration from an earlier version of the application, then I will help "
                + "you copy this. Please click 'OK' to continue.",
                "Configuration changes required", MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            try
            {
                WriteNewConfiguration();
            }
            catch (Exception ex)
            {
                string message = "I failed to write default configuration to "
                    + MainForm.DATA_PATH + "\\notpod-config.xml. I can "
                    + "not continue without this configuration.";
                
                l.Error(message, ex);

                MessageBox.Show(message, "Configuation failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }

            try
            {
                WriteNewDeviceConfiguration();
            }
            catch (Exception ex)
            {
                string message = "I failed to write default device configuration to "
                    + MainForm.DATA_PATH + "\\device-config.xml.\n\nI can "
                    + "not continue without this configuration.";

                l.Error(message, ex);

                MessageBox.Show(message, "Configuation failure",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false;
            }



            if (MessageBox.Show("Do you want me to import old device configuration from a previous version of "
                                + "Notpod, or iTunes Agent?\n\nIf this is a fresh installation of Notpod, not "
                                + "an upgrade, you can safely choose 'No'.", "Upgrade device configuration?", 
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FolderBrowserDialog folders = new FolderBrowserDialog();
                folders.ShowNewFolderButton = false;
                folders.SelectedPath = GetLikelyPreNotpodPath();                                
                folders.Description = "Please choose the installation folder of your pre Notpod installation";

                if (folders.ShowDialog() == DialogResult.OK)
                {
                    string appPath = folders.SelectedPath;

                    // Existing configuration 
                    try
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(Configuration));
                        Configuration oldConfig = (Configuration)deserializer.Deserialize(
                            new XmlTextReader(new StreamReader(appPath + "\\ita-config.xml")));
                        Configuration newConfig = new Configuration();
                        newConfig.ShowNotificationPopups = oldConfig.ShowNotificationPopups;
                        newConfig.UseListFolder = oldConfig.UseListFolder;

                        XmlSerializer serializer = new XmlSerializer(typeof(Configuration));
                        XmlTextWriter xtw = new XmlTextWriter(new StreamWriter(MainForm.DATA_PATH
                            + "\\notpod-config.xml"));
                        serializer.Serialize(xtw, newConfig);
                        xtw.Close();

                    }
                    catch (Exception ex)
                    {
                        string message = "I was unable to read the old configuration file in " + appPath
                            + ", or write existing configuration to the new location " + MainForm.DATA_PATH
                            + "\\notpod-config.xml. I will now exit. You may start me again and try another "
                            + "time, or simply continue using the new default configration.\n\nError was: "
                            + ex.Message;

                        l.Error(message, ex);

                        MessageBox.Show(message,
                            "Failed to locate configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return false;
                    }

                    // Existing device configuration
                    try
                    {
                        XmlSerializer deserializer = new XmlSerializer(typeof(DeviceConfiguration));
                        DeviceConfiguration oldConfig = (DeviceConfiguration)deserializer.Deserialize(
                            new XmlTextReader(new StreamReader(appPath + "\\device-config.xml")));
                        DeviceConfiguration newConfig = (DeviceConfiguration)deserializer.Deserialize(
                            new XmlTextReader(new StringReader(Resources.device_config)));

                        foreach (SyncPattern sp in oldConfig.SyncPatterns) {
                            
                            if(!newConfig.ContainsSyncPattern(sp)) {
                                newConfig.AddSyncPattern(sp);
                            }
                        }

                        foreach (Device d in oldConfig.Devices)
                            newConfig.AddDevice(d);


                        XmlSerializer serializer = new XmlSerializer(typeof(DeviceConfiguration));
                        XmlTextWriter xtw = new XmlTextWriter(new StreamWriter(MainForm.DATA_PATH
                            + "\\device-config.xml"));
                        serializer.Serialize(xtw, newConfig);
                        xtw.Close();

                    }
                    catch (Exception ex)
                    {
                        string message = "I was unable to read the old configuration file in " + appPath
                            + ", or write existing configuration to the new location " + MainForm.DATA_PATH
                            + "\\notpod-config.xml. I will now exit. You may start me again and try another "
                            + "time, or simply continue using the new default configration.\n\nError was: "
                            + ex.Message;

                        l.Error(message, ex);

                        MessageBox.Show(message,
                            "Failed to locate configuration", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                        return false;
                    }

                
                }            
            }

            // Done. Write file indicating that the upgrade was successful.
            try
            {
                FileStream convertDoneFile = File.Create(MainForm.DATA_PATH + "\\.ita-convert");
                convertDoneFile.Close();
                MessageBox.Show("I have successfully configured myself and we're ready to go. Enjoy!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                l.Error(ex);

                MessageBox.Show("I failed to move configuration for the new version. Please try restarting the application.", "Fatal", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return false ;
            }

            return true;
                                
        }
        
        static string GetLikelyPreNotpodPath()
        {
            string dataPath = ConfigurationHelper.GetAppDataPath();
            
            l.Info("Determining likely pre Notpod data path from \"" + dataPath + "\".");
            
            int corpIndex = dataPath.IndexOf("Jaran Nilsen");
            string pathBeforeCorp = dataPath.Substring(0, corpIndex);
            pathBeforeCorp += "Jaran Nilsen\\iTunes Agent";
            
            return pathBeforeCorp;
        }

        /// <summary>
        /// Write new device configuration. Since 1.2.
        /// </summary>
        protected static void WriteNewDeviceConfiguration()
        {
            StreamWriter fw = new StreamWriter(MainForm.DATA_PATH + "\\device-config.xml");
            fw.Write(Resources.device_config);
            fw.Flush();
            fw.Close();
        }

        /// <summary>
        /// Write new default configuration. Since 1.2.
        /// </summary>
        /// 
        protected static void WriteNewConfiguration()
        {
            StreamWriter fw = new StreamWriter(MainForm.DATA_PATH + "\\notpod-config.xml");
            fw.Write(Resources.ita_config);
            fw.Flush();
            fw.Close();
        }

        /// <summary>
        /// Get the data path to use by the application. The path returned by the runtime 
        /// also contains the version number, but the path should be used without any version 
        /// number.
        /// </summary>
        /// <returns></returns>
        public static String GetAppDataPath()
        {
            string original = Application.UserAppDataPath;
            return original.Substring(0, original.LastIndexOf("\\"));
        }
    }
}
