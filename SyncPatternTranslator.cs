using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
using Notpod.Configuration12;
using log4net;
namespace Notpod
{
    /// <summary>
    /// Contains methods for translating a synchronization patterns into a file paths.
    /// </summary>
    public class SyncPatternTranslator
    {
        private static ILog l = LogManager.GetLogger(typeof(SyncPatternTranslator));

        /// <summary>
        /// Translate a SyncPattern into a string using the provided IITFileOrCDTrack.
        /// Currently translating the following macros:
        /// %ARTIST%        = The artist name
        /// %ALBUMARTIST%   = The album artist name
        /// %ALBUM%         = The album name
        /// %ALBUMINITIAL% 	= The album initial
        /// %NAME%          = The track name
        /// %TRACKNUMINPLAYLIST% = Play order index from playlist with leading zero
        /// %TRACKNUMSPACE% = The track number with a trailing space
        /// %TRACKNUM%      = The track number (no trailing space)
        /// %DISCNUMDASH%   = The disc number with a trailing minus and space
        /// %DISCNUM%       = The disc number (no trailing space)
        /// </summary>
        /// <param name="pattern">SyncPattern to translate.</param>
        /// <param name="track">iTunes track containing track information.</param>
        /// <returns>A string representation of pattern and track.</returns>
        public static string Translate(SyncPattern pattern, IITFileOrCDTrack track)
        {
            try
            {
                if (track == null)
                    l.Debug("Track is null!");

                if (track.Location == null)
                {
                    l.Debug("track.Location is null!");
                    throw new MissingTrackException(track);
                }

                string patternstring = ((track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0) ? pattern.CompilationsPattern : pattern.Pattern);

                patternstring = TranslateArtist(pattern, track, patternstring);
                patternstring = TranslateArtistInitial(pattern, track, patternstring);
                patternstring = TranslateTrackNumberInPlaylist(track, patternstring);
                patternstring = TranslateAlbumArtist(pattern, track, patternstring);
                patternstring = TranslateDiscNumber(track, patternstring);
                patternstring = TranslateAlbum(track.Album, patternstring);
                patternstring = TranslateName(track, patternstring);
                patternstring = TranslateTrackNumber(track, patternstring);
                patternstring = TranslateExtension(track, patternstring);

                l.Debug("patternstring=" + patternstring);

                return FileNameUtils.ConvertIllegalCharacters(patternstring);
            }
            catch (MissingTrackException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                string message = "Failed to translate track information according to the "
                    + "defined pattern for this device (" + ex.Message + ").";

                l.Error(message, ex);
                throw new ArgumentException(message, ex);
            }            
            
        }
        
		private static string TranslateArtistInitial(SyncPattern pattern, IITFileOrCDTrack track, string patternstring)
		{
			string artist = (track.Artist == null ? "Unknown Artist" : track.Artist);            
            if (track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0)
                artist = "Compilations";

            patternstring = patternstring.Replace("%ARTISTINITIAL%", artist.Substring(0,1).ToUpper());
            return patternstring;
		}

        /// <summary>
        /// Translate track playorder index from playlist.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateTrackNumberInPlaylist(IITFileOrCDTrack track, string patternstring)
        {
            //%TRACKNUMINPLAYLIST%
            patternstring = patternstring.Replace("%TRACKNUMINPLAYLIST%",
                (track.PlayOrderIndex.ToString().Length == 1 ? "00" + track.PlayOrderIndex.ToString()
                    : "0" + track.PlayOrderIndex.ToString())
            );
            return patternstring;
        }

        /// <summary>
        /// Translate file extension.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateExtension(IITFileOrCDTrack track, string patternstring)
        {
            int extensionstart = track.Location.LastIndexOf(".");
            patternstring = patternstring + track.Location.Substring(extensionstart, track.Location.Length - extensionstart);
            return patternstring;
        }

        /// <summary>
        /// Translate track name.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateName(IITFileOrCDTrack track, string patternstring)
        {
            patternstring = patternstring.Replace("%NAME%", (track.Name == null ? "Unknown Track" : track.Name));
            return patternstring;
        }

        /// <summary>
        /// Translate track number.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateTrackNumber(IITFileOrCDTrack track, string patternstring)
        {
            //Replace track number with a number only if the iTunes track has this field set
            if (track.TrackNumber != 0)
            {
                //%TRACKNUMSPACE%
                patternstring = patternstring.Replace("%TRACKNUMSPACE%",
                    (track.TrackNumber.ToString().Length == 1 ?
                    "0" + track.TrackNumber.ToString() : track.TrackNumber.ToString()) + " ");

                //%TRACKNUM%
                patternstring = patternstring.Replace("%TRACKNUM%",
                    (track.TrackNumber.ToString().Length == 1 ?
                    "0" + track.TrackNumber.ToString() : track.TrackNumber.ToString()));
            }
            else //If there are no track number set for the track
            {
                //%TRACKNUMSPACE%
                patternstring = patternstring.Replace("%TRACKNUMSPACE%", "");
                //%TRACKNUM%
                patternstring = patternstring.Replace("%TRACKNUM%", "");
            }
            return patternstring;
        }

        /// <summary>
        /// Translate track album.
        /// </summary>
        /// <param name="trackAlbum"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateAlbum(string trackAlbum, string patternstring)
        {
            string album = (trackAlbum == null ? "Unknown Album" : trackAlbum);
            patternstring = patternstring.Replace("%ALBUM%", album);
            return patternstring;
        }

        /// <summary>
        /// Translate track artist.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateArtist(SyncPattern pattern, IITFileOrCDTrack track, string patternstring)
        {
            string artist = (track.Artist == null ? "Unknown Artist" : track.Artist);            
            if (track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0)
                artist = "Compilations";

            patternstring = patternstring.Replace("%ARTIST%", artist);
            return patternstring;
        }
        
          /// <summary>
        /// Translate track album artist.
        /// </summary>
        /// <param name="pattern"></param>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateAlbumArtist(SyncPattern pattern, IITFileOrCDTrack track, string patternstring)
        {
            string artist = (track.AlbumArtist == null ? "Unknown Artist" : track.AlbumArtist);            
            if (track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0)
                artist = "Compilations";

            patternstring = patternstring.Replace("%ALBUMARTIST%", artist);
            return patternstring;
        }
        
        /// <summary>
        /// Translate disc number.
        /// </summary>
        /// <param name="track"></param>
        /// <param name="patternstring"></param>
        /// <returns></returns>
        private static string TranslateDiscNumber(IITFileOrCDTrack track, string patternstring)
        {
            //Replace track number with a number only if the iTunes track has this field set
            if (track.DiscNumber != 0 && track.DiscCount > 1)
            {
                //%DISCNUMDASH%%
                patternstring = patternstring.Replace("%DISCNUMDASH%",
                    track.DiscNumber.ToString() + "-");

                //%DISCNUM%
                patternstring = patternstring.Replace("%DISCNUM%",
                    track.DiscNumber.ToString());
            }
            else //If there are no track number set for the track
            {
                //%DISCNUMDASH%
                patternstring = patternstring.Replace("%DISCNUMDASH%", "");
                //%DISCNUM%
                patternstring = patternstring.Replace("%DISCNUM%", "");
            }
            return patternstring;
        }
        
    }
}