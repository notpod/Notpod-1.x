using System;
using System.Collections.Generic;
using System.Text;
using iTunesLib;
namespace Notpod
{
    public class MissingTrackException : ApplicationException
    {
        private IITFileOrCDTrack track;

        public MissingTrackException(IITFileOrCDTrack track) : base()
        {
            this.track = track;
        }

        public IITFileOrCDTrack Track {

            get { return track; }        
        }
    }
}
