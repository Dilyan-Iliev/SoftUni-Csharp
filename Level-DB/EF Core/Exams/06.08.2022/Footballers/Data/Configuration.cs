namespace Footballers.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"Server = .\SQLEXPRESS;
                                                Database = FootballersExam;
                                                Integrated Security = true;
                                                Trust Server Certificate = true";
    }
}
