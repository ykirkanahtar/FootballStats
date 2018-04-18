using System.Collections.Generic;
using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Models
{
    public class TeamDetail
    {
        public TeamDetail()
        {
            PlayerStats = new List<PlayerMatchStat>();
        }

        public TeamResponse TeamInfo { get; set; }
        public decimal AgeRatio { get; set; }
        public List<PlayerMatchStat> PlayerStats { get; set; }
        public StatResponse TeamStats { get; set; }
    }
}