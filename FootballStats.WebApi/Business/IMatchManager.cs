using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;
using FootballStats.Contracts.Requests;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Business
{
    public interface IMatchManager : IBusinessManager
    {
        Task<Match> CreateAsync(MatchRequest request);
        Task<Match> UpdateAsync(int id, MatchRequest request);
        Task DeleteAsync(int id);
        Task<Match> GetByIdAsync(int id);
        Task<CustomEntityList<Match>> GetAllAsync();
    }
}
