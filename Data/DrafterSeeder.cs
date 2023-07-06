using Drafter.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Drafter.Data
{
    public class DrafterSeeder
    {
        private readonly DrafterContext _ctx;
        private readonly IWebHostEnvironment _env;
        private readonly UserManager<DrafterUser> _userManager;

        public DrafterSeeder(DrafterContext ctx, IWebHostEnvironment env, UserManager<DrafterUser> userManager)
        {
            _ctx = ctx;
            _env = env;
            _userManager = userManager;
        }

        public async Task Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Players.Any()) // if no players create it
            {   
                //REMOVE BELOW FREEAGENTUSER CREATOIN. THERE'S SOME ODD SITUATION WITH IT
                DrafterUser user1 = new DrafterUser()
                {
                    UserName = "AdamSilver23",
                    Email = "NBACommish@hotmail.com"
                };
                var result1 = await _userManager.CreateAsync(user1, "P@ssw0rd!");
                if (result1 != IdentityResult.Success) throw new InvalidOperationException("Could not create new users in seeder");
                
                DrafterUser user1forteam = await _userManager.FindByNameAsync(user1.UserName);
                FantasyTeam freeAgentTeam = new FantasyTeam()
                {
                    Name = "Free Agents",
                    DrafterUser = user1forteam
                };
                _ctx.FantasyTeams.Add(freeAgentTeam);
                // REMOVE ABOVE FREE AGENT TEAM CREATOIN
                var filePath = Path.Combine(_env.ContentRootPath,"Data/players.csv");
                IEnumerable<Player> players = File.ReadAllLines(filePath)
                    .Skip(1)
                    .Select(p => Player.FromCsv(p,freeAgentTeam))
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
