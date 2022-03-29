using System;

namespace Greater_of_Two_Values
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string valueType = Console.ReadLine();

            if (valueType == "int")
            {
                int mainMethodNum1 = int.Parse(Console.ReadLine());
                int mainMethodNum2 = int.Parse(Console.ReadLine());
                int mainMethodResult = GetMax(mainMethodNum1, mainMethodNum2);
                Console.WriteLine(mainMethodResult);
            }
            else if (valueType == "char")
            {
                char mainMethodSymbol1 = char.Parse(Console.ReadLine());
                char mainMethodSymbol2 = char.Parse(Console.ReadLine());
                char mainMethodResult = GetMax(mainMethodSymbol1, mainMethodSymbol2);
                Console.WriteLine(mainMethodResult);
            }
            else if (valueType == "string")
            {
                string mainMethodInput1 = Console.ReadLine();
                string mainMethodInput2 = Console.ReadLine();
                string mainMethodResult = GetMax(mainMethodInput1, mainMethodInput2);
                Console.WriteLine(mainMethodResult);
            }

        }

        static int GetMax(int num1, int num2)
        {
            int result = 0;
            if (num1 > num2)
            {
                result = num1;
                // return result; //мога и директно return num1 без да имам горе този result
            }
            else  //не мога да оставя else if , понеже трябва винаги да се излиза с else + return
            {
                result = num2;
                //return result; //мога и директно return num2 без да имам горе този result
            }
            return result; //ако махна return-ите в if-else проверките мога да го оставя само тук
        }

        static char GetMax(char symbol1, char symbol2)
        {
            char result = '0';
            if (symbol1 > symbol2)
            {
                result = symbol1;
                //return result;//мога и директно return symbol1 без да имам горе този result
            }
            else //не мога да оставя else if , понеже трябва винаги да се излиза с else + return
            {
                result = symbol2;
                // return result; //мога и директно return symbol2 без да имам горе този result
            }
            return result; //ако махна return-ите в if-else проверките мога да го оставя само тук
        }

        static string GetMax(string input1, string input2)
        {
            //int stringsComparison = input1.CompareTo(input2); Понеже този метод връща int
            string result = string.Empty;

            if (input1.CompareTo(input2) >= 0) //мога да каже if (stringComparison>=0)
            {
                result = input1;
                return input1;
                //return result; //мога и директно return input1 без да имам горе този result
            }
            else //не мога да оставя else if , понеже трябва винаги да се излиза с else + return
            {
                result = input2;
                // return result; //мога и директно return input2 без да имам горе този result
            }
            return result; //ако махна return-ите в if-else проверките мога да го оставя само тук

            ////CompareTo Method : 
            //example with explanation
            //     private static string CompareStrings(string str1, string str2)
            //{
            //    // Compare the values, using the CompareTo method on the first string.
            //    int cmpVal = str1.CompareTo(str2);

            //    if (cmpVal == 0) // The strings are the same.
            //        return "The strings occur in the same position in the sort order.";
            //    else if (cmpVal < 0)
            //        return "The first string precedes the second in the sort order.";
            //    else
            //        return "The first string follows the second in the sort order.";
            //}

        }
    }
}
