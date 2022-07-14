namespace Stealer
{
    using System;

    public class Program
    {
        static void Main()
        {
            Spy spy = new Spy();
            string result =spy.AnalyzeAccessModifiers("Hacker");
            Console.WriteLine(result);
        }
    }
}
