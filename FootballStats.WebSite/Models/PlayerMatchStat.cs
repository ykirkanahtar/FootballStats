using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Models
{
    public class PlayerMatchStat
    {
        public PlayerResponse Player { get; set; }
        public StatResponse Stat { get; set; }
    }
}