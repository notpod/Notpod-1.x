/*
 * Created by SharpDevelop.
 * User: jaran
 * Date: 01.07.2012
 * Time: 19:05
 *
 */
using System;

namespace Notpod
{
    /// <summary>
    /// Description of PlaylistAssociation.
    /// </summary>
    public class PlaylistAssociation
    {
        
        private long playlistID;
        
        private String playlistName;
        
        public PlaylistAssociation()
        {
        }
        
        public static PlaylistAssociation NewInstance(long playlistID, string name) {
            
            PlaylistAssociation association = new PlaylistAssociation();
            association.playlistID = playlistID;
            association.playlistName = name;
            
            return association;
        }
        
        public long PlaylistID {
         
            get { return playlistID; }
            set { playlistID = value; }
        }

        public string PlaylistName {

            get { return playlistName; }
            set { playlistName = value; }
        }
        
        public override string ToString() {
            
            return this.playlistName;
        }
    }
}
