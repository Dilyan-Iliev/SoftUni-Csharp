﻿namespace Trucks.Data
{
    public static class Configuration
    {
        public static string ConnectionString = @"Server = .\SQLEXPRESS;
                                                Database = Trucks;
                                                Integrated Security = true;
                                                Trust Server Certificate = true";
    }
}