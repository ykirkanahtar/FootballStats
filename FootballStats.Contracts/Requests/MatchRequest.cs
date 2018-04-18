﻿using System;

namespace FootballStats.Contracts.Requests
{
    public class MatchRequest
    {
        public DateTime MatchDate { get; set; }
        public int Order { get; set; }
        public int DurationInMinutes { get; set; }
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
        public string VideoLink { get; set; }
    }
}
