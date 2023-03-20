namespace Theatre.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"Server = .\SQLEXPRESS;
                                                Database = Theatre;
                                                Integrated Security = true;
                                                Trust Server Certificate = true";
    }
}
