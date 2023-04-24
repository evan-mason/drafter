using Drafter.Data.Entities;

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
                //REMOVE BELOW LATER ON ONCE WE CAN JUST CREATE A TEAM IN UI
                var admin = new FantasyTeam()
                {
                    Name = "Admins Team",
                    User = new User()
                    {
                        Name = "Admin"
                    },
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
