using CustomFramework.WebApiUtils.Authorization.AutoMapper;
using FootballStats.Contracts.Requests;
using FootballStats.Contracts.Responses;
using FootballStats.WebApi.Models;

namespace FootballStats.WebApi.AutoMapper
{
    public class MappingProfile : AuthorizationMappingProfile
    {
        public MappingProfile()
        {
            Map();

            CreateMap<Match, MatchResponse>();
            CreateMap<MatchRequest, Match>();

            CreateMap<Player, PlayerResponse>();
            CreateMap<PlayerRequest, Player>();

            CreateMap<Stat, StatResponse>();
            CreateMap<StatRequest, Stat>();

            CreateMap<Team, TeamResponse>();
            CreateMap<TeamRequest, Team>();
        }
    }
}