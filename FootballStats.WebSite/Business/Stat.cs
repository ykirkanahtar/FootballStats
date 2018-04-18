using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using FootballStats.Contracts.Responses;
using FootballStats.WebSite.Enums;
using FootballStats.WebSite.Utils;
using Newtonsoft.Json;

namespace FootballStats.WebSite.Business
{
    public class Stat : IStat
    {
        private readonly IWebApiConnector _webApiConnector;

        public Stat(IWebApiConnector webApiConnector)
        {
            _webApiConnector = webApiConnector;
        }

        public async Task<List<StatResponse>> GetStatsByMatchId(int matchId)
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall/matchid/{matchId}";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }

            throw new Exception(response.Message);
        }

        public async Task<List<StatResponse>> GetStatsByPlayerId(int playerId)
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall/playerid/{playerId}";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }

            throw new Exception(response.Message);
        }

        public async Task<List<StatResponse>> GetAll()
        {
            var getUrl = $"{Constants.DefaultApiRoute}/stat/getall";
            var response = await _webApiConnector.GetAsync(getUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return
                    JsonConvert.DeserializeObject<List<StatResponse>>(response.Result.ToString());

            }

            throw new Exception(response.Message);
        }


        public StatResponse AddPlayerStatToTeamStats(StatResponse teamStats, StatResponse playerStat)
        {
            teamStats.Assist += playerStat.Assist;
            teamStats.Goal += playerStat.Goal;
            teamStats.MissedPenalty += playerStat.MissedPenalty;
            teamStats.OwnGoal += playerStat.OwnGoal;
            teamStats.PenaltyScore += playerStat.PenaltyScore;

            return teamStats;
        }

        public StatResponse GetPlayerStatByMatchIdAndTeamId(int playerId, int teamId, IList<StatResponse> matchStats)
        {
            return matchStats.FirstOrDefault(p => p.TeamId == teamId && p.PlayerId == playerId);
        }

        public StatResponse GetTotalStats(IList<StatResponse> playerStats)
        {
            return new StatResponse
            {
                Goal = (from p in playerStats select p.Goal).Sum(),
                OwnGoal = (from p in playerStats select p.OwnGoal).Sum(),
                Assist = (from p in playerStats select p.Assist).Sum(),
                MissedPenalty = (from p in playerStats select p.MissedPenalty).Sum(),
                PenaltyScore = (from p in playerStats select p.PenaltyScore).Sum(),
            };
        }

        public StatResponse GetPerMatchStats(StatResponse totalStats, List<StatResponse> playerStats)
        {
            var matchCount = GetMatchCount(playerStats);

            return new StatResponse
            {
                Goal = (totalStats.Goal / matchCount).RoundValue(),
                OwnGoal = (totalStats.OwnGoal / matchCount).RoundValue(),
                Assist = (totalStats.Assist / matchCount).RoundValue(),
                MissedPenalty = (totalStats.MissedPenalty / matchCount).RoundValue(),
                PenaltyScore = (totalStats.PenaltyScore / matchCount).RoundValue(),
            };
        }

        public IList<MatchScore> GetMatchFormsByPlayerId(IList<StatResponse> allMatchStats, int playerId)
        {
            var matchForms = new List<MatchScore>();

            var matches = allMatchStats.GroupBy(p => p.MatchId).Select(p => p.First().Match).OrderByDescending(p => p.MatchDate).OrderByDescending(p => p.Order).ToList();

            foreach (var match in matches)
            {
                var matchStats = allMatchStats.Where(p => p.MatchId == match.Id).ToList();
                var homeTeamScore = GetScoreByStatsAndTeamId(matchStats, match.HomeTeamId, match.AwayTeamId);
                var awayTeamScore = GetScoreByStatsAndTeamId(matchStats, match.AwayTeamId, match.HomeTeamId);

                if (matchStats.Where(p => p.TeamId == match.HomeTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    //iki takımda da oynadıysa
                    if (matchStats.Where(p => p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                    {
                        matchForms.Add(homeTeamScore == awayTeamScore ? MatchScore.Draw : MatchScore.BothOfTeam);
                    }
                    else
                    {
                        if (homeTeamScore > awayTeamScore) matchForms.Add(MatchScore.Win);
                        else if (homeTeamScore < awayTeamScore) matchForms.Add(MatchScore.Loose);
                        else matchForms.Add(MatchScore.Draw);
                    }
                }
                else if (matchStats.Where(p => p.TeamId == match.AwayTeamId && p.PlayerId == playerId).ToList().Count > 0)
                {
                    if (homeTeamScore > awayTeamScore) matchForms.Add(MatchScore.Loose);
                    else if (homeTeamScore < awayTeamScore) matchForms.Add(MatchScore.Win);
                    else matchForms.Add(MatchScore.Draw);
                }
            }

            return matchForms;
        }

        public decimal GetScoreByStatsAndTeamId(IList<StatResponse> matchStats, int teamId, int otherTeamId)
        {
            var goalCount = decimal.Truncate((from p in matchStats
                                              where p.TeamId == teamId
                                              select p.Goal + p.PenaltyScore).Sum());

            var ownGoalCount = decimal.Truncate((from p in matchStats
                                                 where p.TeamId == otherTeamId
                                                 select p.OwnGoal).Sum());

            return goalCount + ownGoalCount;
        }

        public int GetTotalWinsByMatchForms(IList<MatchScore> matchForms)
        {
            return matchForms.Count(p => p == MatchScore.Win);
        }

        public int GetTotalLoosesByMatchForms(IList<MatchScore> matchForms)
        {
            return matchForms.Count(p => p == MatchScore.Loose);
        }

        public int GetWinRatioByMatchForms(IList<MatchScore> matchForms)
        {
            var totalWins = GetTotalWinsByMatchForms(matchForms);
            var totalMatchCount = matchForms.Count(p => matchForms.Contains(MatchScore.Win) || matchForms.Contains(MatchScore.Loose) || matchForms.Contains(MatchScore.Draw));
            return totalMatchCount > 0 ? ((totalWins * 100) / totalMatchCount) : 0;
        }

        public int GetLooseRatioByMatchForms(IList<MatchScore> matchForms)
        {
            var totalLooses = GetTotalLoosesByMatchForms(matchForms);
            var totalMatchCount = matchForms.Count(p => matchForms.Contains(MatchScore.Win) || matchForms.Contains(MatchScore.Loose) || matchForms.Contains(MatchScore.Draw));
            return totalMatchCount > 0 ? ((totalLooses * 100) / totalMatchCount) : 0;
        }

        public int GetMatchCount(IList<StatResponse> stats)
        {
            return stats.Select(p => p.MatchId).Distinct().Count();
        }

        public decimal GetTotalGoal(decimal goal, decimal penaltyScore)
        {
            return goal + penaltyScore;
        }

        public decimal GetPerMatchTotalGoal(decimal totalPoint, int matchCount)
        {
            return matchCount > 0 ? totalPoint / matchCount : 0;
        }

        public decimal GetPerMatchPositionalGoal(decimal totalPositionalGoal, int matchCount)
        {
            return matchCount > 0 ? totalPositionalGoal / matchCount : 0;
        }

        public decimal GetPenaltyRatio(decimal penaltyScore, decimal missing)
        {
            return ((penaltyScore + missing) > 0 ?
                (penaltyScore * 100) / (penaltyScore + missing) : 0).RoundValue();
        }

    }
}
