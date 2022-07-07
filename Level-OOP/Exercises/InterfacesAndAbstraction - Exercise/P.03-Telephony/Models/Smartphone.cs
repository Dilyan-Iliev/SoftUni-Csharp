using System;
using System.Linq;
using PracticeForJudge.Exceptions;
using PracticeForJudge.Models.Interfaces;

namespace PracticeForJudge.Models
{
    public class Smartphone : ICaller, IBrowser
    {
        public string Browse(string URL)
        {
            if (URL.Any(x => char.IsDigit(x)))
            {
                throw new ArgumentException(ErrorMessage.InvalidURL);
            }

            return $"Browsing: {URL}!";
        }

        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException(ErrorMessage.InvalidNumber);
            }

            return $"Calling... {number}";
        }
    }
}
