using Drafter.Data.Entities;
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

        public DrafterRepository(DrafterContext ctx, ILogger<DrafterRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }
        
        //DEBUG METHOD REMOVE LATER
        public void CreateKevy()
        {
            _ctx.Add<FantasyTeam>(new FantasyTeam()
            {
                Name = "albuquerque isotopes",
                User = new User()
                {
                    Name = "kevy"
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

        public IEnumerable<Player> GetAllFreeAgentPlayers()
        {
            _logger.LogInformation("Get all free agents was called");
            return _ctx.Players
                .OrderByDescending(p => p.Points)
                .Where(p => p.FantasyTeam.Id == 1)
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

        public IEnumerable<FantasyTeam> GetMyTeams(int userId)
        {
            _logger.LogInformation("Get all products was called");
            return _ctx.FantasyTeams
                .Where(u => u.Id == userId)
                .Include(f => f.Players.OrderByDescending(p => p.Points))
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void DraftPlayer(int id, int teamId)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == id);

            var lastPickPlayer = _ctx.Players// this is so we can get the next draft number
                .OrderByDescending(p => p.DraftPosition)
                .FirstOrDefault();

            var currentPick = lastPickPlayer == null ? 0 : lastPickPlayer.DraftPosition + 1; // pick is 0 if null, else it's next number

            if (player != null)
            {
                var team = _ctx.FantasyTeams.SingleOrDefault(F => F.Id == teamId);
                player.FantasyTeam = team;
                player.DraftPosition = currentPick;
                _ctx.SaveChanges();
            }
        }

        public void UndraftPlayer(int id)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == id);

            if (player != null)
            {
                var team = _ctx.FantasyTeams.SingleOrDefault(F => F.Id == 1);
                player.FantasyTeam = team;
                player.DraftPosition = 0;
                _ctx.SaveChanges();
            }
        }

        public IEnumerable<Player> GetTimeline()
        {
            _logger.LogInformation("Get timeline was called");
            return _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderBy(p => p.DraftPosition)
                .Where(p => p.FantasyTeam.Id != 1) // shouldn't need calling but eh.
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
