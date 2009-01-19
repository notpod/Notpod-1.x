using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;

namespace Jaranweb.iTunesAgent.Test
{
    /// <summary>
    /// Mock implementation of IITFileOrCDTrack.
    /// </summary>
    public class MockFileOrCDTrack : IITFileOrCDTrack
    {
        private string album;
        private string artist;
        private string name;
        private int tracknumber;
        private string location;
        private int bookmarktime;

        #region IITFileOrCDTrack Members

        public IITArtwork AddArtworkFromFile(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Album
        {
            get
            {
                return album;
            }
            set
            {
                album = value;
            }
        }

        public string Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value;
            }
        }

        public IITArtworkCollection Artwork
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int BPM
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int BitRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Category
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Comment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool Compilation
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Composer
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public DateTime DateAdded
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public void Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Description
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int DiscCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int DiscNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Duration
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string EQ
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool Enabled
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool ExcludeFromShuffle
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Finish
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Genre
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void GetITObjectIDs(out int sourceID, out int playlistID, out int trackID, out int databaseID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string Grouping
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Index
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public ITTrackKind Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string KindAsString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Location
        {
            get { return Location; }
            set { location = value; }
        }

        public string LongDescription
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Lyrics
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public DateTime ModificationDate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public void Play()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PlayOrderIndex
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int PlayedCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public DateTime PlayedDate
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public IITPlaylist Playlist
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool Podcast
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int Rating
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public bool RememberBookmark
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int SampleRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int Size
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int Start
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string Time
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int TrackCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int TrackDatabaseID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int TrackNumber
        {
            get
            {
                return tracknumber;
            }
            set
            {
                tracknumber = value;
            }
        }

        public void UpdateInfoFromFile()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void UpdatePodcastFeed()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int VolumeAdjustment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Year
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int playlistID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int sourceID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public int trackID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }
        
        public int BookmarkTime
        {
            get
            {
                return bookmarktime;
            }
            set
            {
                bookmarktime = value;
            }
        }
        #endregion

        #region IITFileOrCDTrack Members


        #endregion

        #region IITFileOrCDTrack Members

        IITArtwork IITFileOrCDTrack.AddArtworkFromFile(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IITFileOrCDTrack.Album
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.AlbumArtist
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Artist
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        IITArtworkCollection IITFileOrCDTrack.Artwork
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.BPM
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.BitRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.BookmarkTime
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Category
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Comment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.Compilation
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Composer
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITFileOrCDTrack.DateAdded
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        void IITFileOrCDTrack.Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IITFileOrCDTrack.Description
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.DiscCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.DiscNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Duration
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITFileOrCDTrack.EQ
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.Enabled
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.EpisodeID
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.EpisodeNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.ExcludeFromShuffle
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Finish
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Genre
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        void IITFileOrCDTrack.GetITObjectIDs(out int sourceID, out int playlistID, out int trackID, out int databaseID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IITFileOrCDTrack.Grouping
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Index
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        ITTrackKind IITFileOrCDTrack.Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITFileOrCDTrack.KindAsString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITFileOrCDTrack.Location
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITFileOrCDTrack.LongDescription
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Lyrics
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITFileOrCDTrack.ModificationDate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITFileOrCDTrack.Name
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.PartOfGaplessAlbum
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        void IITFileOrCDTrack.Play()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IITFileOrCDTrack.PlayOrderIndex
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.PlayedCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITFileOrCDTrack.PlayedDate
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        IITPlaylist IITFileOrCDTrack.Playlist
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        bool IITFileOrCDTrack.Podcast
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.Rating
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.RememberBookmark
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.SampleRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.SeasonNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Show
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Size
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.Size64High
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.Size64Low
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.SkippedCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITFileOrCDTrack.SkippedDate
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortAlbum
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortAlbumArtist
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortArtist
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortComposer
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.SortShow
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Start
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITFileOrCDTrack.Time
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.TrackCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.TrackDatabaseID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.TrackNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITFileOrCDTrack.Unplayed
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        void IITFileOrCDTrack.UpdateInfoFromFile()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        void IITFileOrCDTrack.UpdatePodcastFeed()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        ITVideoKind IITFileOrCDTrack.VideoKind
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.VolumeAdjustment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.Year
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITFileOrCDTrack.playlistID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.sourceID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITFileOrCDTrack.trackID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IITTrack Members

        IITArtwork IITTrack.AddArtworkFromFile(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IITTrack.Album
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITTrack.Artist
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        IITArtworkCollection IITTrack.Artwork
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.BPM
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.BitRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITTrack.Comment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITTrack.Compilation
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITTrack.Composer
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITTrack.DateAdded
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        void IITTrack.Delete()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IITTrack.DiscCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.DiscNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.Duration
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITTrack.EQ
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        bool IITTrack.Enabled
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.Finish
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITTrack.Genre
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        void IITTrack.GetITObjectIDs(out int sourceID, out int playlistID, out int trackID, out int databaseID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        string IITTrack.Grouping
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.Index
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        ITTrackKind IITTrack.Kind
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITTrack.KindAsString
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        DateTime IITTrack.ModificationDate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITTrack.Name
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        void IITTrack.Play()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IITTrack.PlayOrderIndex
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.PlayedCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        DateTime IITTrack.PlayedDate
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        IITPlaylist IITTrack.Playlist
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.Rating
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.SampleRate
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.Size
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.Start
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        string IITTrack.Time
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.TrackCount
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.TrackDatabaseID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.TrackNumber
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.VolumeAdjustment
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.Year
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITTrack.playlistID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.sourceID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITTrack.trackID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion

        #region IITObject Members

        void IITObject.GetITObjectIDs(out int sourceID, out int playlistID, out int trackID, out int databaseID)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        int IITObject.Index
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        string IITObject.Name
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        int IITObject.TrackDatabaseID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITObject.playlistID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITObject.sourceID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        int IITObject.trackID
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        #endregion
    }
}
