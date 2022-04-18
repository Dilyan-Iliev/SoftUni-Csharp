using System;
using System.IO;

namespace P._07_Folder_Size
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double size = GetLength("D:/Test");

            using StreamWriter writer = new StreamWriter("../../../Output.txt") ;
            writer.WriteLine($"{size} KB");


        }
        static double GetLength(string directory)
        {
            double size = 0;
            string[] files = Directory.GetFiles(directory);
            string[] subDirectories = Directory.GetDirectories(directory);

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                size += fileInfo.Length;
            }
            foreach (string subDirectory in subDirectories)
            {
                size += GetLength(subDirectory);
            }


            return size * 0.000001;
        }

    }
}
