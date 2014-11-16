using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using iTunesLib;
using Notpod;
using Notpod.Configuration12;

namespace Notpod.Test
{
    
    [TestFixture]
    public class SyncPatternTranslatorTest
    {
        
        [Test]
        public void TestTranslate()
        {
            SyncPattern pattern = new SyncPattern();
            pattern.Pattern = "%ARTIST%\\%ALBUM%\\%NAME%";

            MockFileOrCDTrack track = new MockFileOrCDTrack();
            track.Artist = "Coldplay";
            track.Album = "X&Y";
            track.Name = "Fix You";
            track.Location = "C:\\Music\\Coldplay\\X&Y\\Fix You.mp3";

            Assert.AreEqual("Coldplay\\X&Y\\Fix You.mp3", 
                SyncPatternTranslator.Translate(pattern, track, 0));
        }

    }
}
