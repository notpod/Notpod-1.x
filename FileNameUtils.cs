using System;
using System.Collections.Generic;
using System.Text;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Contains methods of handling file names.
    /// </summary>
    public class FileNameUtils
    {

        /// <summary>
        /// Converts illegal characters in filename into an underscore character.
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Filename with illegal characters converted to underscore</returns>
        public static string ConvertIllegalCharacters(string filename)
        {
            string[] illegal = new string[] { ":", "*", "?", "\"", "<", ">", "|", "/", };
            string replaceWith = "_";
            foreach (string ic in illegal)
                filename = filename.Replace(ic, replaceWith);

            filename = filename.Replace(".\\", "_\\");
            filename = filename.Replace(",\\", "_\\");
            filename = filename.Replace(" \\", "_\\");

            return filename;
        }
    }
}
