﻿namespace MainTask.LogFiles.Interfaces
{
    public interface ILogFile
    {
        int Size { get; }

        void Write(string message);
    }
}
