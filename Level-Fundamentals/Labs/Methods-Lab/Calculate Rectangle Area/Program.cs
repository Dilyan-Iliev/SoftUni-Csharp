using System;

namespace Calculate_Rectangle_Area
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mainMethodHeight = double.Parse(Console.ReadLine());
            double mainMethodWidth = double.Parse(Console.ReadLine());
            double area = RectangleArea(mainMethodHeight, mainMethodWidth); //т.е при методи, които връщат данни трябва
            //така да си направя променлива, която да води до съответния метод, който връща съответния резултат.
            Console.WriteLine(area);
        }

        static double RectangleArea(double height, double width)
        {
            double area = height* width;
            return area;
        }
    }
}
