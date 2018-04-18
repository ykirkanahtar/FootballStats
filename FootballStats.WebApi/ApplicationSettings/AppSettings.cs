﻿using CustomFramework.WebApiUtils.Authorization.Utils;

namespace FootballStats.WebApi.ApplicationSettings
{
    public class AppSettings
    {
        public AppSettings()
        {
            Token = new Token();
        }

        public int DefaultListCount { get; set; }
        public int IterationCountForHashing { get; set; }
        public Token Token { get; set; }
    }
}