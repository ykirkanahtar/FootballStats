using System.Collections.Generic;
using System.Threading.Tasks;
using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Business
{
    public interface IPlayer
    {
        Task<PlayerResponse> GetById(int playerId);

        Task<List<PlayerResponse>> GetAll();

        List<PlayerResponse> GetPlayersByTeamIdAndStats(int teamId, List<StatResponse> stats);
    }
}
