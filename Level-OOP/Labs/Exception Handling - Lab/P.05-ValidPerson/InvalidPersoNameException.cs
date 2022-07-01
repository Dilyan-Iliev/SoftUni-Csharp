using System;
using System.Collections.Generic;
using System.Text;

namespace P._05_ValidPerson
{
    public class InvalidPersoNameException : Exception
    {
        public InvalidPersoNameException()
        {
        }

        public InvalidPersoNameException(string message)
            : base(message)
        {

        }
    }
}
