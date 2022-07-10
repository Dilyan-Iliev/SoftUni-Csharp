using MainTask.LogFiles.Interfaces;
using System.Linq;
using System.Text;

namespace MainTask.LogFiles
{
    public class LogFile : ILogFile
    {
        private StringBuilder sb;

        public LogFile()
        {
            this.sb = new StringBuilder();
        }

        public int Size => sb.ToString()
            .Where(x => char.IsLetter(x))
            .Sum(x => x);

        public void Write(string message)
         => sb.Append(message);
    }
}
