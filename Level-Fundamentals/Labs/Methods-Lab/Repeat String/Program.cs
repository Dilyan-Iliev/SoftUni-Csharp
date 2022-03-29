using System;
using System.Text;

namespace Repeat_String
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string mainMethodInput = Console.ReadLine();
            int mainMethodCount = int.Parse(Console.ReadLine());

            string mainMethodRepeat = PrintRepeatString(mainMethodInput,mainMethodCount);
            Console.WriteLine(mainMethodRepeat);  
        }

        static string PrintRepeatString(string input, int count)
        {
            //StringBuilder е като контейнер, в който се нанизват stringovete като масив
            var repeat = new StringBuilder(); // or StringBuilder repeat = new StringBuilder();

            //string repeat = String.Empty; а в цикъла - > repeat = repeat + input;
            for (int i = 1; i <= count; i++)
            {
                repeat.Append(input);
            }
            return repeat.ToString();
        }



    }
}
