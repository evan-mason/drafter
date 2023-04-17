using Drafter.Data.Entities;
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

        public IEnumerable<Player> GetAllPlayers()
        {
            _logger.LogInformation("Get all products was called");
            return _ctx.Players
                .OrderBy(p => p.Points)
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
                .ToList();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
