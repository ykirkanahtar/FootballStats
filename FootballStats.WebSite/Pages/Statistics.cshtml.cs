using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FootballStats.WebSite.Business;
using FootballStats.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballStats.WebSite.Pages
{
    public class StatisticModel : PageModel
    {
        private readonly IPlayer _player;
        private readonly IStat _stat;

        public List<StatisticDetail> StatisticDetailInfo { get; set; }
        public Statistic StatisticInfo { get; set; }


        public StatisticModel(IPlayer player, IStat stat)
        {
            _player = player;
            _stat = stat;
            StatisticDetailInfo = new List<StatisticDetail>();
        }

        public async Task OnGet()
        {
            var matchStats = await _stat.GetAll();

            var players = await _player.GetAll();

            foreach (var player in players)
            {
                try
                {
                    var playerStats = await _stat.GetStatsByPlayerId(player.Id);
                    var statisticDetail = new StatisticDetail();

                    var totalStats = _stat.GetTotalStats(playerStats);

                    var matchCount = _stat.GetMatchCount(playerStats);

                    var perMatchStats = _stat.GetPerMatchStats(totalStats, playerStats);

                    statisticDetail.Player = player;
                    statisticDetail.MatchCount = matchCount;
                    statisticDetail.TotalStatDetail = totalStats;
                    statisticDetail.PerMatchStatDetail = perMatchStats;

                    statisticDetail.MatchForms = _stat.GetMatchFormsByPlayerId(matchStats, player.Id);

                    statisticDetail.WinRatio = _stat.GetWinRatioByMatchForms(statisticDetail.MatchForms);

                    statisticDetail.LooseRatio = _stat.GetLooseRatioByMatchForms(statisticDetail.MatchForms);

                    statisticDetail.PenaltyRatio = _stat.GetPenaltyRatio(totalStats.PenaltyScore, totalStats.MissedPenalty);

                    statisticDetail.TotalGoal = _stat.GetTotalGoal(totalStats.Goal, totalStats.PenaltyScore);
                    statisticDetail.PerMatchPositionGoal = _stat.GetPerMatchPositionalGoal(totalStats.Goal, matchCount);
                    statisticDetail.PerMatchTotalGoal = _stat.GetPerMatchTotalGoal(statisticDetail.TotalGoal, matchCount);

                    StatisticDetailInfo.Add(statisticDetail);
                }
                catch (Exception)//Oyuncuya ait istatistik yoksa
                {

                }
            }

            StatisticInfo = new Statistic(StatisticDetailInfo);
        }
    }
}
