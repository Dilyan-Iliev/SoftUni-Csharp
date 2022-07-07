using System;
using System.Linq;
using PracticeForJudge.Exceptions;
using PracticeForJudge.Models.Interfaces;

namespace PracticeForJudge.Models
{
    public class StationaryPhone : ICaller
    {
        public string Call(string number)
        {
            if (!number.All(char.IsDigit))
            {
                throw new ArgumentException(ErrorMessage.InvalidNumber);
            }

            return $"Dialing... {number}";
        }
    }
}
