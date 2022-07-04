using P._01_StreamProgress.Interfaces;

namespace P._01_StreamProgress.Models
{
    public class StreamProgressInfo
    {
        private readonly IFileType filetType;

        public StreamProgressInfo(IFileType filetType)
        {
            this.filetType = filetType;
        }

        public int CalculateCurrentPercent()
         => (this.filetType.BytesSent * 100) / this.filetType.Length;
    }
}
