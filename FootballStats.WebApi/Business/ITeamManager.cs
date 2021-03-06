﻿using System.Threading.Tasks;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Utils;
using FootballStats.Contracts.Requests;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.Business
{
    public interface ITeamManager : IBusinessManager
    {
        Task<Team> CreateAsync(TeamRequest request);
        Task<Team> UpdateAsync(int id, TeamRequest request);
        Task DeleteAsync(int id);
        Task<Team> GetByIdAsync(int id);
        Task<CustomEntityList<Team>> GetAllAsync();
    }
}
