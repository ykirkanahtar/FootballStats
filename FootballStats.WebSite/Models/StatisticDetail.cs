using System.Collections.Generic;
using FootballStats.Contracts.Responses;
using FootballStats.WebSite.Enums;

namespace FootballStats.WebSite.Models
{
    public class StatisticDetail
    {
        public StatisticDetail()
        {
            MatchForms = new List<MatchScore>();
        }

        public PlayerResponse Player { get; set; }
        public StatResponse TotalStatDetail { get; set; }
        public StatResponse PerMatchStatDetail { get; set; }
        public decimal TotalGoal { get; set; }
        public decimal TotalPositionGoal { get; set; }
        public decimal TotalPenaltyGoal { get; set; }
        public decimal TotalAssist { get; set; }
        public decimal TotalMissedPenaltyCount { get; set; }
        public decimal PerMatchTotalGoal { get; set; }
        public decimal PerMatchPositionGoal { get; set; }

        public decimal PerMatchAsist { get; set; }
        public decimal PerMatchPenaltyGoal { get; set; }
        public decimal PerMatchMissedPenalty { get; set; }

        public decimal PenaltyRatio { get; set; }
        public int MatchCount { get; set; }
        public IList<MatchScore> MatchForms { get; set; }
        public decimal WinRatio { get; set; }
        public decimal LooseRatio { get; set; }
    }
}