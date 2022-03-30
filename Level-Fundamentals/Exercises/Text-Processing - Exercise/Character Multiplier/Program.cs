using System;

namespace Character_Multiplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            string firstString = input[0];
            string secondString = input[1];
            int sum = 0;

            //if (firstString.Length == secondString.Length)
            //{
            //    for (int i = 0; i < firstString.Length; i++)
            //    {
            //        sum += firstString[i] * secondString[i];
            //    }
            //}
            //else
            //{
            //    if (firstString.Length > secondString.Length)
            //    {
            //        for (int i = 0; i < firstString.Length; i++)
            //        {
            //            if (secondString.Length > i)
            //            {
            //                sum += firstString[i] * secondString[i];
            //            }
            //            else
            //            {
            //                sum += firstString[i];
            //            }
            //        }
            //    }
            //    else if (secondString.Length > firstString.Length)
            //    {
            //        for (int i = 0; i < secondString.Length; i++)
            //        {
            //            if (firstString.Length > i)
            //            {
            //                sum += firstString[i] * secondString[i];
            //            }
            //            else
            //            {
            //                sum += secondString[i];
            //            }
            //        }
            //    }
            //}
            //Console.WriteLine(sum);

            //or

            string longerWord = string.Empty;
            string shorterWord = string.Empty;

            if (firstString.Length >= secondString.Length)
            {
                longerWord = firstString;
                shorterWord = secondString;
            }
            else
            {
                longerWord = secondString;
                shorterWord = firstString;
            }

            for (int i = 0; i < shorterWord.Length; i++)
            {
                sum += longerWord[i] * shorterWord[i];
            }

            for (int i = shorterWord.Length; i < longerWord.Length; i++)
            {
                sum += longerWord[i];
            }
            Console.WriteLine(sum);
        }
    }
}
