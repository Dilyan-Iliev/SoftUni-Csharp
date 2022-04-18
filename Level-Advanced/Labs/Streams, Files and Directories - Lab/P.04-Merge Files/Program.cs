using System;
using System.Linq;
using System.IO;

namespace P._04_Merge_Files
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string firstFilePath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.04-Merge Files\first file.txt";
            string secondFilePath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.04-Merge Files\second file.txt";
            string finalFilePath = @"C:\Users\IvonaVelkova\source\repos\Advanced\Advanced - course\Streams, Files and Directories - Lab\P.04-Merge Files\final file.txt";

            string[] firstFile = File.ReadAllLines(firstFilePath);
            string[] secondFile = File.ReadAllLines(secondFilePath);

            using StreamWriter streamWriter = new StreamWriter(finalFilePath);

            int biggerFile = Math.Max(firstFile.Length, secondFile.Length);

            for (int i = 0; i < biggerFile; i++)
            {
                if (i < firstFile.Length)
                {
                    streamWriter.WriteLine(firstFile[i]);
                }
                if (i < secondFile.Length)
                {
                    streamWriter.WriteLine(secondFile[i]);
                }
            }
        }
    }
}
