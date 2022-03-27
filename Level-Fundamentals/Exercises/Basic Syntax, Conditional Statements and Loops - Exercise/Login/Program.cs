using System;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = "";

            for (int i = username.Length-1; i >= 0; i--)
            {
                password += username[i];
            }

            string currentPass = Console.ReadLine();
            int count = 0;

            while (currentPass!=password)
            {
                count++;
                if (count == 4)
                {
                    Console.WriteLine($"User {username} blocked!");
                    return;
                }

                Console.WriteLine("Incorrect password. Try again.");
                currentPass = Console.ReadLine();
            }
            Console.WriteLine($"User {username} logged in.");
        }
    }
}
