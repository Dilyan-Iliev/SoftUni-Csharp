using P._01_StreamProgress.Interfaces;

namespace P._01_StreamProgress.Models
{
    public class Music : IFileType
    {
        public Music(string artist, string album, int length, int bytesSent)
        {
            Artist = artist;
            Album = album;
            Length = length;
            BytesSent = bytesSent;
        }

        public string Artist { get; set; }
        public string Album { get; set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }
    }
}
