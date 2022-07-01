using System;

namespace P._05_ValidPerson
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Person person = new Person("P3t3r", "John", 20);
                Person firstPerson = new Person("John", "Peterson", 50);
                Person secondPerson = new Person("", "Ingrid", 10);
                Person thirdPerson = new Person("Mike", "", 19);
                Person fourthPerson = new Person("Pete", "Oliver", -2);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
    }
}
