using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FootballStats.Contracts.Responses;
using FootballStats.WebSite.Business;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FootballStats.WebSite.Pages
{
    public class PlayerModel : PageModel
    {
        private readonly IPlayer _player;
        public List<PlayerResponse> PlayerList { get; set; }

        public PlayerModel(IPlayer player)
        {
            _player = player;
            PlayerList = new List<PlayerResponse>();
        }

        public async Task OnGet()
        {
            var players = await _player.GetAll();
            PlayerList = players.OrderBy(p => p.Name).ToList();
        }
    }
}
