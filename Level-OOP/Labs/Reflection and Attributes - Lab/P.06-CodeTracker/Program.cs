namespace AuthorProblem
{
    using System;

    [Author("Dilyan")]
    public class StartUp
    {
        [Author("Dilyan")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
