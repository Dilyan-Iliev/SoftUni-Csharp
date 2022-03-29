using System;

namespace Vowels_Count
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToLower();
           int counter =  VowelsCount(input);
            Console.WriteLine(counter);
        }

        static int VowelsCount(string input)
        {
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == 'a'
                    || input[i] == 'i'
                    || input[i] == 'o'  
                    || input[i] == 'u'
                    || input[i] == 'e') 
                    //|| input[i] == 'A'
                    //|| input[i] == 'I'
                    //|| input[i] == 'O'
                    //|| input[i] == 'U'
                    //|| input[i] == 'E')
                {
                    count++;
                }
            }
            return count;



        }
    }
}
