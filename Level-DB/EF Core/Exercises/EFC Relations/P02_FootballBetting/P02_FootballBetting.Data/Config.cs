namespace P02_FootballBetting.Data
{
    public static class Config
    {
        public const string ConnectionString = @"Server = .\SQLEXPRESS;
                                                Database = BettingSystem;
                                                Integrated Security = true;
                                                Trust Server Certificate = true";
    }
}
