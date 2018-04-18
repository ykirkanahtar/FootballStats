using System.Collections.Generic;
using FootballStats.Contracts.Responses;
using FootballStats.WebSite.Models;

namespace FootballStats.WebSite.Business
{
    public interface ITeam
    {
        TeamDetail GetTeamDetailByTeamResponse(IStat stat, TeamResponse team, IList<StatResponse> matchStats);
    }
}
