﻿namespace BookShop.Data
{
    public class Configuration
    {
        public static string ConnectionString
            => @"Server = .\SQLEXPRESS;
                Database = BookShop;
                Integrated Security = true;
                Trust Server Certificate = true";
    }
}
