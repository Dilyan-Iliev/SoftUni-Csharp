using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(10, 5);
            rectangle.Draw();

            Circle circle = new Circle(5);
            circle.Draw();
        }
    }
}
