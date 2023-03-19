namespace Artillery.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"Server = .\SQLEXPRESS;
                                                Database = Artillery;
                                                Integrated Security = true;
                                                Trust Server Certificate = true";
    }
}
