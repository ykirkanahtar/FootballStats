using System.Linq;
using System.Threading.Tasks;
using FootballStats.WebSite.Business;
using FootballStats.WebSite.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballStats.WebSite.Pages
{
    public class MatchDetailModel : PageModel
    {
        private readonly IStat _stat;
        private readonly ITeam _team;

        public MatchDetail MatchDetailInfo { get; set; }

        public MatchDetailModel(IStat stat, ITeam team)
        {
            _stat = stat;
            _team = team;
            MatchDetailInfo = new MatchDetail();
        }

        public async Task OnGet(int id)
        {
            var matchId = id; //TODO routing konusunu araştırınca burayı düzelt

            var matchStats = await _stat.GetStatsByMatchId(matchId);

            var match = matchStats.Select(p => p.Match).Distinct().First();
            MatchDetailInfo.MatchInfo = match;
            MatchDetailInfo.HomeTeam = _team.GetTeamDetailByTeamResponse(_stat, match.HomeTeam, matchStats);
            MatchDetailInfo.AwayTeam = _team.GetTeamDetailByTeamResponse(_stat, match.AwayTeam, matchStats);
        }

    }
}
