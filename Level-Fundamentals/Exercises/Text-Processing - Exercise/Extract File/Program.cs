using System;

namespace Extract_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string[] input = Console.ReadLine().Split('\\'); //прочитам вход, който го разделям по \

            //string fileNameAndExtension = input[input.Length-1]; //последната част от масива е името на файла + разширението му
            //string[] arr = fileNameAndExtension.Split('.'); //правя горния стринг на масив и го разделям по точки
            //string fileName = arr[0];
            //string fileExtension = arr[1];
            //Console.WriteLine($"File name: {fileName}");
            //Console.WriteLine($"File extension: {fileExtension}");

            //or

            string text = Console.ReadLine();
            int lastIndex = text.LastIndexOf('\\'); //или това +1 да е тук извън скобите, а не долу
            string substract = text.Substring(lastIndex+1);
            string[] lastElements = substract.Split('.');
            string fileName = lastElements[0];
            string fileExtension = lastElements[1];
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
