using System.Collections.Generic;
using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Models
{
    public class PlayerStatDetail
    {
        public PlayerStatDetail()
        {
            MatchStats = new List<StatResponse>();
        }
        public List<StatResponse> MatchStats { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
        public StatResponse PlayerStat { get; set; }

    }
}
