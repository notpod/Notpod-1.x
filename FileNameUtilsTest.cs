using System;
using System.Collections.Generic;
using System.Text;
using Jaranweb.iTunesAgent;
using NUnit.Framework;


namespace Jaranweb.iTunesAgent.Test
{
    [TestFixture]
    /// <summary>
    /// Test case for FileNameUtils
    /// </summary>    
    public class FileNameUtilsTest
    {
        [Test]
        public void TestConvertIllegalCharacters()
        {

            string filenamei = "??\\**\\::\\\"\"\\<<\\>>\\||\\\0\\";
            string filenameo = "__\\__\\__\\__\\__\\__\\__\\_\\";

            Assert.AreEqual(filenameo, FileNameUtils.ConvertIllegalCharacters(filenamei));

        }
    }
}
