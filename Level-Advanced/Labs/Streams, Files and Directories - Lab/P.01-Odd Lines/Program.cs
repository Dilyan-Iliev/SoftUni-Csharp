using System;
using System.IO;

namespace P._01_Odd_Lines
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string readPath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.01-Odd Lines\StreamReader.txt";
            string writePath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.01-Odd Lines\StreamWriter.txt";
            using StreamReader sr = new StreamReader(readPath);
            using StreamWriter sw = new StreamWriter(writePath);

            ExtractOddLines(sr, sw);
        }
        private static void ExtractOddLines(StreamReader sr, StreamWriter sw)
        {
            int count = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                if (count % 2 != 0)
                {
                    sw.WriteLine(line);
                }
                count++;
            }
        }
    }
}
