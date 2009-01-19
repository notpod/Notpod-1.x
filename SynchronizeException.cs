using System;
using System.Collections.Generic;
using System.Text;

namespace Jaranweb.iTunesAgent
{
    /// <summary>
    /// Exception class used by ISynchronizer implementations.
    /// </summary>
    public class SynchronizeException : ApplicationException
    {
        /// <summary>
        /// Create a new instance of SynchronizeException.
        /// </summary>
        public SynchronizeException()
            : base()
        {
        }

        /// <summary>
        /// Create a new instance of SynchronizeException.
        /// </summary>
        /// <param name="message">Exception message.</param>
        public SynchronizeException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Create a new instance of SynchronizeException.
        /// </summary>
        /// <param name="message">Exception message.</param>
        /// <param name="innerException">Inner exception.</param>
        public SynchronizeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
