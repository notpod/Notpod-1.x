/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 03.06.2012
 * Time: 16:58
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;

namespace Notpod
{
    [TestFixture]
    public class MainFormTest
    {
        
        
        [Test]
        public void CheckIfITunesLibrary_whenNetworkDrive_correctlyChecksPath()
        {
            MainForm form = new MainForm();
            Assert.IsFalse(form.CheckIfiTunesLibrary("E:\\"));
            
        }
    }
}
