using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
using Jaranweb.iTunesAgent.Configuration12;
using log4net;
namespace Jaranweb.iTunesAgent
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
        /// %ALBUM%         = The album name
        /// %NAME%          = The track name
        /// %TRACKNUMSPACE% = The track number with a trailing space
        /// %TRACKNUM%      = The track number (no trailing space)
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

                string patternstring = ((track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0) ? pattern.CompilationsPattern : pattern.Pattern);

                string artist = (track.Artist == null ? "Unknown Artist" : track.Artist);

                if (track.Compilation && pattern.CompilationsPattern != null && pattern.CompilationsPattern.Length > 0)
                    artist = "Compilations";

                patternstring = patternstring.Replace("%ARTIST%", artist);
                patternstring = patternstring.Replace("%ALBUM%", (track.Album == null ? "Unknown Album" : track.Album));
                patternstring = patternstring.Replace("%NAME%", (track.Name == null ? "Unknown Track" : track.Name));

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

                if (track.Location == null)
                {
                    l.Debug("track.Location is null!");
                    throw new MissingTrackException(track);
                }

                int extensionstart = track.Location.LastIndexOf(".");
                patternstring = patternstring + track.Location.Substring(extensionstart, track.Location.Length - extensionstart);

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
        
    }
}
