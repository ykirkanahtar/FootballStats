﻿using System;

namespace FootballStats.Contracts.Requests

{
    public class PlayerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
