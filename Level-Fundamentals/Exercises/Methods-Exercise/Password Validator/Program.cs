using System;

namespace Password_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string passwordAsInput = Console.ReadLine();

            bool isBetweenSixAndTenChars = PasswordLengthCheck(passwordAsInput);
            bool isOnlyDigitsAndLetters = IsOnlyLettersAndDigits(passwordAsInput);
            bool isAtLeastTwoDigits = IsAtLeastTwoDigits(passwordAsInput);

            if (isBetweenSixAndTenChars == false) //or (!isBetweenSixAndTenChars)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }
            if (isOnlyDigitsAndLetters == false)
            {
                Console.WriteLine("Password must consist only of letters and digits");
            }
            if (isAtLeastTwoDigits == false)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }
            if (isBetweenSixAndTenChars==true
                && isOnlyDigitsAndLetters==true
                && isAtLeastTwoDigits == true)
            {
                Console.WriteLine("Password is valid");
            }


        }

        static bool PasswordLengthCheck(string password)
        {
            bool isValid = false;

            if (password.Length >= 6 && password.Length <= 10)
            {
                return isValid = true;
            }
            else
            {
                return isValid;
            }
        }

        static bool IsOnlyLettersAndDigits(string password)
        {
            bool isValid = false;

            for (int i = 0; i < password.Length; i++)
            {
                if (!char.IsLetterOrDigit(password[i])) // напр. при pass #ASD като види # ще ми даде false, че паролата не е ок
                {
                   return isValid; //срещне ли return излиза от метода
                }
            }
            return true;
        }

        static bool IsAtLeastTwoDigits(string password)
        {
            bool isValid = false;
            int counter = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (char.IsDigit(password[i]))
                {
                    counter++;
                    if (counter >= 2) 
                    {
                        return isValid = true; //срещне ли return излиза от метода
                    }
                }
            }
            return isValid; //т.е. false

        }
    }
}
