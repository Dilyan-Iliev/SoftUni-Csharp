﻿namespace MusicHub.Data
{
    public static class Configuration
    {
        public static string ConnectionString =
                            @"Server = .\SQLEXPRESS;
                            Database = MusicHub;
                            Integrated Security = true;
                            Trust Server Certificate = true";
    }
}
