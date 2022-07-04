using System;

namespace PersonsInfo.IO
{
    public class Writer : IWriter
    {

        public void Write(object message)
        {
            throw new NotImplementedException();
        }

        public void WriteLine(object message)
        {
            Console.WriteLine(message);
        }
    }
}
