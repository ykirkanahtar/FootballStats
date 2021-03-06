﻿using CustomFramework.Data;
using FluentValidation.Attributes;
using FootballStats.WebApi.Validators;

namespace FootballStats.WebApi.Models
{
    [Validator(typeof(StatValidator))]
    public class Stat : BaseModel<int>
    {
        public int MatchId { get; set; }
        public int TeamId { get; set; }
        public int PlayerId { get; set; }

        public decimal Goal { get; set; }
        public decimal OwnGoal { get; set; }
        public decimal PenaltyScore { get; set; }
        public decimal MissedPenalty { get; set; }
        public decimal Assist { get; set; }

        public virtual Match Match { get; set; }
        public virtual Team Team { get; set; }
        public virtual Player Player { get; set; }
    }
}
