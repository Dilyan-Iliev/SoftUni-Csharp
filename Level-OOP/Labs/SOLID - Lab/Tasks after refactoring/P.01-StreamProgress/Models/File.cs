using P._01_StreamProgress.Interfaces;

namespace P._01_StreamProgress.Models
{
    public class File : IFileType
    {
        public File(string name, int length, int bytesSent)
        {
            Name = name;
            Length = length;
            BytesSent = bytesSent;
        }

        public string Name { get; set; }
        public int Length { get; set; }
        public int BytesSent { get; set; }

    }
}
