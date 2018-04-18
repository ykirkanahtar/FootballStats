using System.Collections.Generic;
using System.Threading.Tasks;
using FootballStats.Contracts.Responses;

namespace FootballStats.WebSite.Business
{
    public interface IMatch
    {
        Task<List<MatchResponse>> GetAll();
    }
}
