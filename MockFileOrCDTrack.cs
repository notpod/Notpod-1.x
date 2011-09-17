using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;

namespace Notpod.Test
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
        private bool compilation;
                
        

        public int BookmarkTime
        {
            get
            {
                return bookmarktime;
            }
            set
            {
                this.bookmarktime = value;
            }
        }

        public int TrackNumber
        {
            get
            {
                return tracknumber;
            }
            set
            {
                this.tracknumber = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
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

       
        public string Location
        {
            get { return location; }
            set { location = value; }
        }



        #region IITFileOrCDTrack Members

        public IITArtwork AddArtworkFromFile(string filePath)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public string AlbumArtist
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IITArtworkCollection Artwork
        {
            get { throw new NotImplementedException(); }
        }

        public int BPM
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int BitRate
        {
            get { throw new NotImplementedException(); }
        }

        

        public string Category
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Comment
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Compilation
        {
            get
            {
                return compilation;
            }
            set
            {
                compilation = value;
            }
        }

        public string Composer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime DateAdded
        {
            get { throw new NotImplementedException(); }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int DiscCount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int DiscNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Duration
        {
            get { throw new NotImplementedException(); }
        }

        public string EQ
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool Enabled
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string EpisodeID
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int EpisodeNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool ExcludeFromShuffle
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Finish
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Genre
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void GetITObjectIDs(out int sourceID, out int playlistID, out int trackID, out int databaseID)
        {
            throw new NotImplementedException();
        }

        public string Grouping
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Index
        {
            get { throw new NotImplementedException(); }
        }

        public ITTrackKind Kind
        {
            get { throw new NotImplementedException(); }
        }

        public string KindAsString
        {
            get { throw new NotImplementedException(); }
        }

        public string LongDescription
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Lyrics
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime ModificationDate
        {
            get { throw new NotImplementedException(); }
        }

        

        public bool PartOfGaplessAlbum
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public int PlayOrderIndex
        {
            get { throw new NotImplementedException(); }
        }

        public int PlayedCount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime PlayedDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IITPlaylist Playlist
        {
            get { throw new NotImplementedException(); }
        }

        public bool Podcast
        {
            get { throw new NotImplementedException(); }
        }

        public int Rating
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public bool RememberBookmark
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int SampleRate
        {
            get { throw new NotImplementedException(); }
        }

        public int SeasonNumber
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Show
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Size
        {
            get { throw new NotImplementedException(); }
        }

        public int Size64High
        {
            get { throw new NotImplementedException(); }
        }

        public int Size64Low
        {
            get { throw new NotImplementedException(); }
        }

        public int SkippedCount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public DateTime SkippedDate
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortAlbum
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortAlbumArtist
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortArtist
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortComposer
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string SortShow
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Start
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Time
        {
            get { throw new NotImplementedException(); }
        }

        public int TrackCount
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int TrackDatabaseID
        {
            get { throw new NotImplementedException(); }
        }

        

        public bool Unplayed
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public void UpdateInfoFromFile()
        {
            throw new NotImplementedException();
        }

        public void UpdatePodcastFeed()
        {
            throw new NotImplementedException();
        }

        public ITVideoKind VideoKind
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int VolumeAdjustment
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int Year
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public int playlistID
        {
            get { throw new NotImplementedException(); }
        }

        public int sourceID
        {
            get { throw new NotImplementedException(); }
        }

        public int trackID
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
        
        public int AlbumRating {
            get {
                throw new NotImplementedException();
            }
            set {
                throw new NotImplementedException();
            }
        }
        
        public ITRatingKind AlbumRatingKind {
            get {
                throw new NotImplementedException();
            }
        }
        
        public ITRatingKind ratingKind {
            get {
                throw new NotImplementedException();
            }
        }
        
        public IITPlaylistCollection Playlists {
            get {
                throw new NotImplementedException();
            }
        }
        
        public DateTime ReleaseDate {
            get {
                throw new NotImplementedException();
            }
        }
        
        public void Reveal()
        {
            throw new NotImplementedException();
        }
    }
}
