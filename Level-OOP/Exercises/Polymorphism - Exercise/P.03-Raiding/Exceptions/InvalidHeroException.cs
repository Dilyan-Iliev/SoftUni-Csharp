namespace PracticeForJudge.Exceptions
{
    using System;

    public class InvalidHeroException : Exception
    {
        public InvalidHeroException(string message)
            : base(message)
        {
            InvalidHeroMessage = message;
        }

        public string InvalidHeroMessage { get; }
    }
}
