using System;
using System.Collections.Generic;
using System.Text;
using Notpod;
using NUnit.Framework;


namespace Notpod.Test
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
