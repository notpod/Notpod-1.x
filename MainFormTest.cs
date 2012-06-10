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
using Rhino.Mocks;
using iTunesLib;

namespace Notpod
{
    [TestFixture]
    public class MainFormTest
    {
        
    	private MockRepository mockrepo = new MockRepository();
        
        [Test]
        public void CheckIfITunesLibrary_whenNetworkDrive_correctlyChecksPath()
        {

        	var appFactory = MockRepository.GenerateStub<ITunesAppFactory>();
        	var mockITunes = MockRepository.GenerateStub<iTunesApp>();
        	
        	appFactory.Stub(x => x.GetNewInstance()).Return(mockITunes);
        	
        	mockITunes.Stub(x => x.Version).Return("Test");
        	mockITunes.Stub(x => x.LibraryXMLPath).Return("\\\\networkdrive");
        	
        	MainForm form = new MainForm();
        	form.ITunesAppFactory = appFactory;
        	form.SetITunesInstance();
            Assert.IsFalse(form.CheckIfiTunesLibrary("E:\\"));
            
        }
    }
}
