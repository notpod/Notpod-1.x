/*
 * Created by SharpDevelop.
 * User: Jaran
 * Date: 15.01.2012
 * Time: 12:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Notpod.Configuration12
{
    /// <summary>
    /// Description of Class1.
    /// </summary>
    public class SyncPatternCollection
    {
        
        private ICollection<SyncPattern> syncPatterns = new List<SyncPattern>();

        
        /// <summary>
        /// Accessor for syncPatterns.
        /// </summary>
        public SyncPattern[] SyncPatterns
        {
            get
            {
                SyncPattern[] patterns = new SyncPattern[syncPatterns.Count];
                syncPatterns.CopyTo(patterns, 0);
                return patterns;
            }
            set
            {
                syncPatterns.Clear();
                foreach (SyncPattern sp in value)
                    syncPatterns.Add(sp);
            }
        }
        
        public ICollection<SyncPattern> GetAsList() {
            
            return syncPatterns;
        }

    }
}
