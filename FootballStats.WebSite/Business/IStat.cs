using System.Collections.Generic;
using System.Threading.Tasks;
using FootballStats.Contracts.Responses;
using FootballStats.WebSite.Enums;

namespace FootballStats.WebSite.Business
{
    public interface IStat
    {
        Task<List<StatResponse>> GetStatsByMatchId(int matchId);

        Task<List<StatResponse>> GetStatsByPlayerId(int playerId);

        Task<List<StatResponse>> GetAll();

        StatResponse AddPlayerStatToTeamStats(StatResponse teamStats, StatResponse playerStat);

        StatResponse GetPlayerStatByMatchIdAndTeamId(int playerId, int teamId, IList<StatResponse> matchStats);

        StatResponse GetTotalStats(IList<StatResponse> playerStats);

        StatResponse GetPerMatchStats(StatResponse totalStats, List<StatResponse> playerStats);

        IList<MatchScore> GetMatchFormsByPlayerId(IList<StatResponse> allMatchStats, int playerId);

        decimal GetScoreByStatsAndTeamId(IList<StatResponse> matchStats, int teamId, int otherTeamId);

        int GetTotalWinsByMatchForms(IList<MatchScore> matchForms);

        int GetTotalLoosesByMatchForms(IList<MatchScore> matchForms);

        int GetWinRatioByMatchForms(IList<MatchScore> matchForms);

        int GetLooseRatioByMatchForms(IList<MatchScore> matchForms);

        int GetMatchCount(IList<StatResponse> stats);

        decimal GetTotalGoal(decimal goal, decimal penaltyScore);

        decimal GetPerMatchTotalGoal(decimal totalGoal, int matchCount);

        decimal GetPerMatchPositionalGoal(decimal totalPositionalGoal, int matchCount);

        decimal GetPenaltyRatio(decimal penaltyScore, decimal missing);

    }
}
