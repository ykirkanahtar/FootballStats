using System.Linq;
using System.Threading.Tasks;
using FootballStats.WebSite.Business;
using FootballStats.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballStats.WebSite.Pages
{
    public class PlayerDetailModel : PageModel
    {
        private readonly IPlayer _player;
        private readonly IStat _stat;

        public PlayerDetail PlayerDetailInfo { get; set; }

        public PlayerDetailModel(IPlayer player, IStat stat)
        {
            _player = player;
            _stat = stat;
            PlayerDetailInfo = new PlayerDetail();
        }

        public async Task OnGet(int id)
        {
            var playerId = id;

            var player = await _player.GetById(playerId);
            PlayerDetailInfo.Player = player;

            var playerStats = await _stat.GetStatsByPlayerId(playerId);
            playerStats = playerStats.OrderBy(p => p.Match.MatchDate).ThenBy(p => p.Match.Order).ThenBy(p => p.Team.Id).ToList();

            var totalStats = _stat.GetTotalStats(playerStats);

            var perMatchStats = _stat.GetPerMatchStats(totalStats, playerStats);

            PlayerDetailInfo.PenaltyRatio = _stat.GetPenaltyRatio(totalStats.PenaltyScore, totalStats.MissedPenalty);

            PlayerDetailInfo.TotalStats = totalStats;
            PlayerDetailInfo.PerMatchStats = perMatchStats;

            var allMatchStats = await _stat.GetAll();

            PlayerDetailInfo.MatchForms = _stat.GetMatchFormsByPlayerId(allMatchStats, playerId);
            PlayerDetailInfo.TotalWins = _stat.GetTotalWinsByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.TotalLooses = _stat.GetTotalLoosesByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.WinRatio = _stat.GetWinRatioByMatchForms(PlayerDetailInfo.MatchForms);
            PlayerDetailInfo.LooseRatio = _stat.GetLooseRatioByMatchForms(PlayerDetailInfo.MatchForms);

            foreach (var stat in playerStats)
            {
                var playerStatDetail = new PlayerStatDetail
                {
                    PlayerStat = stat,
                    MatchStats = await _stat.GetStatsByMatchId(stat.MatchId)
                };

                playerStatDetail.HomeTeamScore = _stat.GetScoreByStatsAndTeamId(playerStatDetail.MatchStats, stat.Match.HomeTeamId, stat.Match.AwayTeamId);
                playerStatDetail.AwayTeamScore = _stat.GetScoreByStatsAndTeamId(playerStatDetail.MatchStats, stat.Match.AwayTeamId, stat.Match.HomeTeamId);

                PlayerDetailInfo.PlayerStats.Add(playerStatDetail);
            }
        }

    }
}
