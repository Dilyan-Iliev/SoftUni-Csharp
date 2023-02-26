namespace P02_FootballBetting
{
    using P02_FootballBetting.Data;

    public class StartUp
    {
        static void Main()
        {
            var dbContext = new FootballBettingContext();
        }
    }
}