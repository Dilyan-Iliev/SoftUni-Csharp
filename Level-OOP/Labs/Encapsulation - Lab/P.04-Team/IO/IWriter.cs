namespace PersonsInfo.IO
{
    public interface IWriter
    {
        void Write(object message);
        void WriteLine(object message);
    }
}
