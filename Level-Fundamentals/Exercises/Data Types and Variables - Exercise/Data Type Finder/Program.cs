using System;

namespace Data_Type_Finder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //from More Exercises

            string input = Console.ReadLine();

            while (input != "END")
            {
                //int result = 0;
                // bool success = int.TryParse(input, out result); // usually TryParse returns true or false;

                string dataType = string.Empty; //ще се занулява при всяка следваща итерация понеже е вътре в цикъла, а не отвън

                if (int.TryParse(input, out _))
                {
                    dataType = "integer";
                }
                else if (double.TryParse(input, out _))
                {
                    dataType = "floating point";
                }
                else if (bool.TryParse(input, out _))
                {
                    dataType = "boolean";
                }
                else if (char.TryParse(input, out _))
                {
                    dataType = "character";
                }
                else // since you cannot parse to string
                {
                    dataType = "string";
                }
                Console.WriteLine($"{input} is {dataType} type");

                input = Console.ReadLine();
            }


            // or

            //string input = Console.ReadLine();
            //int inputAsInt;
            //double inputAsDoube;
            //char inputAsChar;
            //bool inputAsBool;


            //while (input!="END")
            //{
            //    string dataType = string.Empty;
            //    if (int.TryParse(input, out inputAsInt))
            //    {
            //        dataType = "integer";
            //    }
            //    else if (double.TryParse(input, out inputAsDoube))
            //    {
            //        dataType = "floating point";
            //    }
            //    else if (bool.TryParse(input, out inputAsBool))
            //    {
            //        dataType="boolean";
            //    }
            //    else if (char.TryParse(input, out inputAsChar))
            //    {
            //        dataType = "character";
            //    }
            //    else
            //    {
            //        dataType = "string";
            //    }
            //    Console.WriteLine($"{input} is {dataType} type");

            //    input = Console.ReadLine();
            //}
        }
    }
}
