using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Models
{
    public class MatchDetail
    {
        public MatchResponse MatchInfo { get; set; }
        public TeamDetail HomeTeam { get; set; }
        public TeamDetail AwayTeam { get; set; }
        public decimal HomeTeamScore { get; set; }
        public decimal AwayTeamScore { get; set; }
    }
}
