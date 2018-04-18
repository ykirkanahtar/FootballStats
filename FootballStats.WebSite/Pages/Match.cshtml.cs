using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballStats.WebSite.Business;
using FootballStats.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballStats.WebSite.Pages
{
    public class MatchModel : PageModel
    {
        private readonly IMatch _match;
        private readonly IStat _stat;
        public List<MatchDetail> Matches { get; set; }

        public MatchModel(IMatch match, IStat stat)
        {
            _match = match;
            _stat = stat;
            Matches = new List<MatchDetail>();
        }

        public async Task OnGet()
        {
            var matches = await _match.GetAll();

            foreach (var match in matches)
            {
                var matchDetail = new MatchDetail();
                var matchStats = await _stat.GetStatsByMatchId(match.Id);

                matchDetail.MatchInfo = matchStats.Select(p => p.Match).Distinct().FirstOrDefault();

                matchDetail.HomeTeamScore = _stat.GetScoreByStatsAndTeamId(matchStats, matchDetail.MatchInfo.HomeTeamId, matchDetail.MatchInfo.AwayTeamId);
                matchDetail.AwayTeamScore = _stat.GetScoreByStatsAndTeamId(matchStats, matchDetail.MatchInfo.AwayTeamId, matchDetail.MatchInfo.HomeTeamId);

                Matches.Add(matchDetail);
            }
            var sortedMatches = Matches.OrderBy(p => p.MatchInfo.MatchDate).ThenBy(p => p.MatchInfo.Order).ToList();
            Matches = sortedMatches;
        }
    }

}
