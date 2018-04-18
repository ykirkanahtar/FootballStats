using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;
using FootballStats.Contracts.Requests;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Business
{
    public interface IPlayerManager : IBusinessManager
    {
        Task<Player> CreateAsync(PlayerRequest request);
        Task<Player> UpdateAsync(int id, PlayerRequest request);
        Task DeleteAsync(int id);
        Task<Player> GetByIdAsync(int id);
        Task<CustomEntityList<Player>> GetAllAsync();
    }
}