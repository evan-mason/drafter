using Drafter.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Drafter.Data
{
    public class DrafterSeeder
    {
        private readonly DrafterContext _ctx;
        private readonly IWebHostEnvironment _env;

        public DrafterSeeder(DrafterContext ctx, IWebHostEnvironment env)
        {
            _ctx = ctx;
            _env = env;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Players.Any()) // if no players create it
            {
                var freeAgentTeam = new FantasyTeam()
                {
                    Name = "Free Agents",
                    User = new User()
                    {
                        Name = "Adam Silver"
                    },
                };
                _ctx.FantasyTeams.Add(freeAgentTeam);

                var filePath = Path.Combine(_env.ContentRootPath,"Data/players.csv");
                IEnumerable<Player> players = File.ReadAllLines(filePath)
                    .Skip(1)
                    .Select(p => Player.FromCsv(p, freeAgentTeam))
                    .ToList();

                _ctx.Players.AddRange(players);
                _ctx.SaveChanges();
            }
        }

        public void Destroy()
        {
            _ctx.Database.EnsureDeleted();
        }
    }
}
