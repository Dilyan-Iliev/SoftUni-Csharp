using System;
using System.IO;

namespace P._02_2._Line_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.02-Line Numbers\Old text.txt";
            string writePath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.02-Line Numbers\New text.txt";

            using StreamReader streamReader = new StreamReader(readPath);
            using StreamWriter streamWriter = new StreamWriter(writePath);

            int count = 1;
            while (!streamReader.EndOfStream)
            {
                string currentLine = streamReader.ReadLine();

                streamWriter.WriteLine($"{count}. {currentLine}");

                count++;
            }
        }
    }
}
