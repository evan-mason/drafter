using Drafter.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data
{
    public class DrafterRepository : IDrafterRepository
    {
        private readonly DrafterContext _ctx;
        private readonly ILogger<DrafterRepository> _logger;
        private readonly UserManager<DrafterUser> _userManager;

        public DrafterRepository(DrafterContext ctx, ILogger<DrafterRepository> logger, UserManager<DrafterUser> userManager)
        {
            _ctx = ctx;
            _logger = logger;
            _userManager = userManager;
        }
        
        //DEBUG METHOD REMOVE LATER, ALSO IS NOT WORKING
        public void CreateKevy()
        {
            _ctx.Add<FantasyTeam>(new FantasyTeam()
            {
                Name = "albuquerque isotopes",
                DrafterUser = new DrafterUser()
                {
                    UserName = "kevy"
                }
            });

            _ctx.SaveChanges();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            _logger.LogInformation("Get all players was called");
            return _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.Points)
                .ToList();
        }

        public async Task<IEnumerable<Player>> GetAllFreeAgentPlayers()
        {
            _logger.LogInformation("Get all free agents was called");

            DrafterUser FreeAgentUser = await _userManager.FindByNameAsync("AdamSilver23");

            return _ctx.Players
                .OrderByDescending(p => p.Points)
                .Where(p => p.FantasyTeam.DrafterUser == FreeAgentUser)
                .ToList();  
        }

        public IEnumerable<Player> GetPlayerByName(string name)
        {
            return _ctx.Players
                .Where(p => p.Name == name)
                .ToList();
        }

        public IEnumerable<Player> GetPlayerByPosition(string position)
        {
            return _ctx.Players
                .Where(p => p.Position == position)
                .OrderByDescending(p => p.Points)
                .ToList();
        }

        public async Task<IEnumerable<FantasyTeam>> GetMyTeams(string userName) // THIS ISN'T WORKING AS IT'S NOT BEING USED
        {
            _logger.LogInformation("Get all products was called");

            DrafterUser MyUser = await _userManager.FindByNameAsync(userName);

            return _ctx.FantasyTeams
                .Where(u => u.DrafterUser == MyUser)
                .Include(f => f.Players.OrderByDescending(p => p.Points))
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public async Task DraftPlayer(int id, int teamId)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == id);

            var lastPickPlayer = _ctx.Players// this is so we can get the next draft number
                .OrderByDescending(p => p.DraftPosition)
                .FirstOrDefault();

            var currentPick = lastPickPlayer == null ? 0 : lastPickPlayer.DraftPosition + 1; // pick is 0 if null, else it's next number

            DrafterUser adminUser = await _userManager.FindByNameAsync("Admin");

            if (player != null)
            {
                var team = _ctx.FantasyTeams.SingleOrDefault(F => F.DrafterUser == adminUser);
                player.FantasyTeam = team;
                player.DraftPosition = currentPick;
                _ctx.SaveChanges();
            }
        }

        public async Task UndraftPlayer(int id)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == id);

            DrafterUser FreeAgentUser = await _userManager.FindByNameAsync("AdamSilver23");

            if (player != null)
            {
                var team = _ctx.FantasyTeams.SingleOrDefault(F => F.DrafterUser == FreeAgentUser);
                player.FantasyTeam = team;
                player.DraftPosition = 0;
                _ctx.SaveChanges();
            }
        }

        public async Task<IEnumerable<Player>> GetTimeline()
        {
            _logger.LogInformation("Get timeline was called");

            DrafterUser FreeAgentUser = await _userManager.FindByNameAsync("AdamSilver23");

            return _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderBy(p => p.DraftPosition)
                .Where(p => p.FantasyTeam.DrafterUser != FreeAgentUser) // shouldn't need calling but eh.
                .ToList();
        }

        public IEnumerable<Pick> GetPicks()
        {
            return _ctx.Picks
                .OrderBy(p => p.PickNumber)
                .Include(p => p.FantasyTeam)
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .ToList();
        }

        public Pick GetNextPick()
        {
            var NextPick = _ctx.Picks
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .Include(p => p.FantasyTeam)
                .FirstOrDefault();
            if (NextPick != null)
            {
                return NextPick;
            }
            else return new Pick { PickNumber = 9999 };
        }
    }
}
