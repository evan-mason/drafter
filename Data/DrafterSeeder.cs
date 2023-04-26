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
                DrafterUser user1 = new DrafterUser()
                {
                    UserName = "AdamSilver23",
                    Email = "NBACommish@hotmail.com"
                };
                var result1 = await _userManager.CreateAsync(user1, "P@ssw0rd!fasdf1@@");
                if (result1 != IdentityResult.Success) throw new InvalidOperationException("Could not create new users in seeder");

                DrafterUser user2 = new DrafterUser()
                {
                    UserName = "Admin",
                    Email = "Adminitaur@hotmail.com"
                };
                var result2 = await _userManager.CreateAsync(user2, "P@ssw0rd!fasdf1@@");
                if (result2 != IdentityResult.Success) throw new InvalidOperationException("Could not create new users in seeder");

                DrafterUser user1forteam = await _userManager.FindByNameAsync(user1.UserName);
                FantasyTeam freeAgentTeam = new FantasyTeam()
                {
                    Name = "Free Agents",
                    DrafterUser = user1forteam
                };
                _ctx.FantasyTeams.Add(freeAgentTeam);
                //REMOVE BELOW LATER ON ONCE WE CAN JUST CREATE A TEAM IN UI
                DrafterUser user2forteam = await _userManager.FindByNameAsync(user2.UserName);
                FantasyTeam admin = new FantasyTeam()
                {
                    Name = "Admins Team",
                    DrafterUser = user2forteam
                };
                _ctx.FantasyTeams.Add(admin);
                //REMOVE ABOVE
                // CREATE DRAFT
                var rounds = 13;
                var draftType = "Linear";
                ICollection<FantasyTeam> teams = new List<FantasyTeam>() { admin, freeAgentTeam }; // THIS IS THE PICK ORDER!!!!!
                var testDraft = new Draft() // THIS SHOULD BE A NEW DRAFT FUNCTION
                {
                    Name = "Test Draft",
                    DateCreated = DateTime.Now,
                    DraftType = draftType,
                    Rounds = rounds,
                    Teams = teams
                };

                // GENERATE PICKS FUNCTION
                testDraft.Picks = new List<Pick>();
                int pickNumber = 0;
                for (int i = 0; i < rounds; i++)
                {
                    foreach (FantasyTeam team in teams)
                    {
                        pickNumber++;
                        testDraft.Picks.Add( new Pick
                        {
                            PickNumber = pickNumber,
                            FantasyTeam = team
                        });
                    }
                }
                // INITIALISED PICKS ABOVE
                _ctx.Drafts.Add(testDraft);

                var filePath = Path.Combine(_env.ContentRootPath,"Data/players.csv");
                IEnumerable<Player> players = File.ReadAllLines(filePath)
                    .Skip(1)
                    .Select(p => Player.FromCsv(p, freeAgentTeam))
                    .ToList();

                _ctx.Players.AddRange(players);

                //USING PLAYERS, ADD THEM TO THEIR NBA TEAM.

                _ctx.SaveChanges();
            }
        }

        public void Destroy()
        {
            _ctx.Database.EnsureDeleted();
        }
    }
}
