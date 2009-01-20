using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Contains utiliy methods supporting the System.Security.Cryptography namespace.
    /// </summary>
    public class CryptoUtils
    {
        /// <summary>
        /// Compute the MD5 hash and return it in hex format.
        /// </summary>
        /// <param name="original">The original string to compute the MD5 hash for.</param>
        /// <returns>MD5 hex for the original string.</returns>
        public static string Md5Hex(string original)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(original));
            StringBuilder sb = new StringBuilder(32);
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2").ToUpper());
            }
            return sb.ToString().ToLower();
        }
    }
}
