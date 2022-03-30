using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace String_Explosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string input = Console.ReadLine();
            //string[] inputArgs = input.Split('>');
            //string result = inputArgs[0];

            //int remainingPower = 0;

            //for (int i = 1; i < inputArgs.Length; i++)
            //{
            //    result += '>';

            //    string currentString = inputArgs[i];
            //    char digitSymbol = currentString[0];

            //    int power = int.Parse(digitSymbol.ToString()) + remainingPower;

            //    if (power > currentString.Length)
            //    {
            //        remainingPower = power - currentString.Length;
            //    }
            //    else
            //    {
            //        result+= currentString.Substring(power);
            //    }
            //}
            //Console.WriteLine(result);

            //or

            string input = Console.ReadLine();
            var sb = new StringBuilder();
            int bombPower = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currCh = input[i];

                if (currCh == '>')
                {
                    int currBombPower = GetIntValueOfCharacter(input[i + 1]);
                    sb.Append(currCh);
                    bombPower += currBombPower;
                }
                else
                {
                    if (bombPower > 0)// if there is detonated bomb skips the character and decrease bomb power
                    {
                        bombPower--;
                    }
                    else
                    {
                        sb.Append(currCh);
                    }
                }
            }
            Console.WriteLine(sb);
        }

        static int GetIntValueOfCharacter(char ch)
        {
            return (int)ch - 48;
            //or int.Parse(ch.ToString()); 
        }
    }
}
