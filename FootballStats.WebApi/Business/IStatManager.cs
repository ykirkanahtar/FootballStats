using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;
using FootballStats.Contracts.Requests;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Business
{
    public interface IStatManager : IBusinessManager
    {
        Task<Stat> CreateAsync(StatRequest request);
        Task<Stat> UpdateAsync(int id, StatRequest request);
        Task DeleteAsync(int id);
        Task<Stat> GetByIdAsync(int id);
        Task<CustomEntityList<Stat>> GetAllByMatchIdAsync(int matchId);
        Task<CustomEntityList<Stat>> GetAllByPlayerIdAsync(int playerId);
        Task<CustomEntityList<Stat>> GetAllAsync();
    }
}