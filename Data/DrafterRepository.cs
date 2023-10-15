using Drafter.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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

        public IEnumerable<Player> GetAllPlayers()
        {
            _logger.LogInformation("Get all players was called");
            return _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.Points)
                .ToList();
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersDashboard()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.FantasyPointsAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetFreePlayersDashboard()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersForecastedDashboard()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.FantasyPointsPredictedAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetFreePlayersForecastedDashboard()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsPredictedAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersDashboardTotal()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.FantasyPointsTotal)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsTotal, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetFreePlayersDashboardTotal()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsTotal)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsTotal, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetAllPlayersDashboardForecastedTotal()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.FantasyPointsPredictedTotal)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedTotal, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetFreePlayersDashboardForecastedTotal()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsPredictedTotal)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedTotal, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .ToListAsync();
        }

        public async Task<Player> GetSelectedPlayerDashboard(int id)
        {
            _logger.LogInformation("Get selected player with id: " + id + " was called");
            return await _ctx.Players
                .Where(p => p.Id == id)
                .Include(p => p.FantasyTeam)
                .OrderByDescending(p => p.Points)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Player>> GetAllFreeAgentPlayers()
        {
            _logger.LogInformation("Get all free agents was called");

            DrafterUser FreeAgentUser = await _userManager.FindByNameAsync("AdamSilver23");

            return await _ctx.Players
                .OrderByDescending(p => p.Points)
                .Where(p => p.FantasyTeam.DrafterUser == FreeAgentUser)
                .ToListAsync();  
        }

        public IEnumerable<Player> GetPlayerByName(string name)
        {
            return _ctx.Players
                .Where(p => p.Name == name)
                .ToList();
        }

        public async Task<IEnumerable<PlayerDto>> GetFreePlayersForecastedTotalPresenter()
        {
            _logger.LogInformation("Get all players was called");
            return await _ctx.Players
                .Include(p => p.FantasyTeam)
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsPredictedAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .Skip(1)
                .Take(5)
                .ToListAsync();
        }

        public IEnumerable<Player> GetPlayerByPosition(string position)
        {
            return _ctx.Players
                .Where(p => p.Position == position)
                .OrderByDescending(p => p.FantasyPointsAverage)
                .ToList();
        }

        public async Task<PlayerDto> GetLastPickedPresenter()
        {
            return await _ctx.Players
                .OrderByDescending(p => p.DraftPosition) // hacked the id to be draft position. It's actually not but saves me creating another dto
                .Select(p => new PlayerDto() { Id = p.DraftPosition, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedTotal, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FantasyTeam>> GetMyTeam(string userName) // THIS ISN'T WORKING AS IT'S NOT BEING USED
        {
            _logger.LogInformation("Get all products was called");

            DrafterUser MyUser = await _userManager.FindByNameAsync(userName);

            return await _ctx.FantasyTeams
                .Where(u => u.DrafterUser == MyUser)
                .Include(f => f.Players.OrderByDescending(p => p.FantasyPointsAverage))
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetMyPlayersDashboard(string userName)
        {
            _logger.LogInformation("Get all players was called");
            DrafterUser MyUser = await _userManager.FindByNameAsync(userName);

            FantasyTeam MyTeam = await _ctx.FantasyTeams
                .Where(u => u.DrafterUser == MyUser)
                .FirstOrDefaultAsync();

            return await _ctx.Players
                .Where(u => u.FantasyTeam == MyTeam)
                .OrderByDescending(p => p.FantasyPointsAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsAverage, NBATeam = p.NBATeam}) // this should be changed to be forecasted average
                .ToListAsync();
        }

        public async Task<IEnumerable<PlayerDto>> GetTeamPresenter(int drafterPlayerId)
        {
            _logger.LogInformation("Get current team was called");

            FantasyTeam MyTeam = await _ctx.FantasyTeams
                .Where(u => u.Id == drafterPlayerId)
                .FirstOrDefaultAsync();

            return await _ctx.Players
                .Where(u => u.FantasyTeam == MyTeam)
                .OrderByDescending(p => p.FantasyPointsAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsAverage, NBATeam = p.NBATeam }) // this should be changed to be forecasted average
                .ToListAsync();
        }

        public async Task<String> GetTeamNamePresenter(int drafterPlayerId)
        {
            _logger.LogInformation("Get current team name was called");

            return await _ctx.FantasyTeams
                .Where(u => u.Id == drafterPlayerId)
                .Select(p => new String(p.Name))
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetLastPickedVideoNumber()
        {
            // default return is 0 if not found
            return await _ctx.Players
                .Where(p => p.DraftTime < DateTime.Now && p.DraftTime > DateTime.Now.AddSeconds(-5))
                .OrderByDescending(p => p.DraftPosition) // hacked the id to be draft position. It's actually not but saves me creating another dto
                .Select(p => int.Parse(p.PlayerPictureId))
                .FirstOrDefaultAsync();
        }

        public async Task<int> GetTotalTeamsPresenter()
        {
            _logger.LogInformation("Get total teams called");

            return await _ctx.FantasyTeams
                .Where(u => u.Id != 1)
                .CountAsync();
        }

        public bool SaveAll() // CHECKS FOR SUCCESS.
        {
            return _ctx.SaveChanges() > 0;
        }

        public async Task DraftPlayer(int id, string userName)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == id);

            var lastPickPlayer = _ctx.Players// this is so we can get the next draft number
                .OrderByDescending(p => p.DraftPosition)
                .FirstOrDefault();

            var currentPick = lastPickPlayer == null ? 0 : lastPickPlayer.DraftPosition + 1; // pick is 0 if null, else it's next number

            DrafterUser SelectingUser = await _userManager.FindByNameAsync(userName);

            if (GetNextPick().FantasyTeam.DrafterUser != SelectingUser)
            {
                return;
            }

            if (player != null)
            {
                var team = _ctx.FantasyTeams.SingleOrDefault(F => F.DrafterUser == SelectingUser);
                player.FantasyTeam = team;
                player.DraftPosition = currentPick;
                player.DraftTime = DateTime.Now;
                var pickToDelete = _ctx.Picks.FirstOrDefault();
                if (pickToDelete != null)
                {
                    _ctx.Picks.Remove(pickToDelete);
                }
            }

            _ctx.SaveChanges();
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
                player.DraftTime = DateTime.MinValue;
                player.DraftPosition = 0;
                _ctx.SaveChanges();
            }

            //Drafted re-order / fix

            List<Player> draftedPlayers = _ctx.Players
                .OrderByDescending(p => p.DraftPosition)
                .Where(p => p.FantasyTeam.DrafterUser != FreeAgentUser)
                .ToList();

            for (int i = 0; i < draftedPlayers.Count; i++)
            {
                draftedPlayers[i].DraftPosition = i+1;
            }
            _ctx.SaveChanges();
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

        public async Task<IEnumerable<PlayerDto>> GetTimelineDashboard()
        {
            _logger.LogInformation("Get timeline: repo hit");

            DrafterUser FreeAgentUser = await _userManager.FindByNameAsync("AdamSilver23");

            return _ctx.Players
                .Include(p => p.FantasyTeam)
                .OrderBy(p => p.DraftPosition)
                .Where(p => p.FantasyTeam.DrafterUser != FreeAgentUser) // shouldn't need calling but eh.
                .Select(p => new PlayerDto() { Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsAverage, NBATeam = p.NBATeam })
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

        public async Task<DateTime> GetLastPickTime()
        {
            var lastPick = await _ctx.Picks
                .OrderByDescending(p => p.PickTakenTime)
                .FirstOrDefaultAsync();

            if (lastPick != null)
            {
                return lastPick.PickTakenTime;
            }

            else return DateTime.MinValue;
        }

        public async Task<List<Pick>> GetPicksForDashboard()
        {
            return await _ctx.Picks
                .OrderBy(p => p.PickNumber)
                .Include(p => p.FantasyTeam)
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .ToListAsync();
        }

        public async Task<List<Pick>> GetPicksForPresenter()
        {
            return await _ctx.Picks
                .OrderBy(p => p.PickNumber)
                .Include(p => p.FantasyTeam)
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .Take(12)
                .ToListAsync();
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

        public async Task<Pick> GetNextPickDashboard()
        {
            var NextPick = await _ctx.Picks
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .Include(p => p.FantasyTeam)
                .FirstOrDefaultAsync();
            if (NextPick != null)
            {
                return NextPick;
            }
            else return new Pick { PickNumber = 9999 };
        }

        public async Task CreateFantasyTeam(FantasyTeam? fantasyTeam, string? username)
        {
            if (fantasyTeam != null && username != null)
            {
                DrafterUser creator = await _userManager.FindByNameAsync(username);

                fantasyTeam.DrafterUser = creator;
                fantasyTeam.DraftOrder = _ctx.FantasyTeams.Count();
                await _ctx.FantasyTeams.AddAsync(fantasyTeam);  
                //BELOW SHOULD BE REMOVED WHEN WE PICK THE DRAFT WE WANT TO JOIN
                Draft defaultDraft = await _ctx.Drafts
                    .Include(d => d.Teams)
                    .FirstOrDefaultAsync();
                defaultDraft.Teams.Add(fantasyTeam);
            }
        }

        public Draft GetDraftSettings()
        {
            return _ctx.Drafts
                .Include(d => d.Teams.OrderBy(t => t.DraftOrder))
                .ThenInclude(t => t.DrafterUser)
                .FirstOrDefault();
        }

        public async Task CreateDraft(Draft draft, string username)
        {
            DrafterUser creator = await _userManager.FindByNameAsync(username);
            Draft newDraft = draft;
            newDraft.Admin = creator;
            newDraft.DateCreated = DateTime.UtcNow;
            newDraft.StartTime = DateTime.UtcNow.AddMinutes(20);
            await _ctx.Drafts.AddAsync(newDraft);
        }

        public void GenerateDraft()
        {
            Draft defaultDraft = _ctx.Drafts // WE WANT TO PULL THIS OUT OF THE ABOVE METHOD PARAMS AT SOME POINT
                .Include(d => d.Teams.OrderBy(t => t.DraftOrder))
                .FirstOrDefault();

            string draftType = defaultDraft.DraftType;
            defaultDraft.Picks = new List<Pick>();
            int rounds = defaultDraft.Rounds;
            int pickNumber = 0;
            for (int round = 1; round <= rounds; round++)
            {
                if (draftType == "Snake" && round % 2 == 0)
                {
                    for (int team = defaultDraft.Teams.Count; team > 0; team--)
                    {
                        pickNumber++;
                        defaultDraft.Picks.Add(new Pick
                        {
                            PickNumber = pickNumber,
                            FantasyTeam = defaultDraft.Teams[team-1]
                        });
                    }
                }
                else // LINEAR NOT SPECIFIED BUT COULD BE DOWN THE LINE
                {
                    for (int team = 0; team < defaultDraft.Teams.Count; team++)
                    {
                        pickNumber++;
                        defaultDraft.Picks.Add(new Pick
                        {
                            PickNumber = pickNumber,
                            FantasyTeam = defaultDraft.Teams[team]
                        });
                    }
                }
            }
            _ctx.SaveChanges();
        }

        public async Task<PlayerDto> DraftPlayerDashboard(PlayerDto playerDto, string userName)
        {
            var player = _ctx.Players
                .SingleOrDefault(p => p.Id == playerDto.Id);

            var thisPick = await _ctx.Picks 
                .OrderBy(p => p.PickNumber)
                .Where(p => p.PickTakenTime == DateTime.MinValue)
                .FirstOrDefaultAsync();

            DrafterUser SelectingUser = await _userManager.FindByNameAsync(userName);

            if (GetNextPick().FantasyTeam.DrafterUser == SelectingUser && player.FantasyTeam.Name != "Free Agents")
            {
                if (player != null)
                {
                    var team = await _ctx.FantasyTeams.SingleOrDefaultAsync(F => F.DrafterUser == SelectingUser);
                    player.FantasyTeam = team;
                    player.DraftPosition = thisPick.PickNumber;
                    player.DraftTime = DateTime.Now;
                    thisPick!.PickTakenTime = DateTime.UtcNow;

                    _ctx.SaveChanges();
                }
            }

            return new PlayerDto() { 
                Id = player.Id, 
                Name = player.Name, 
                Position = player.Position, 
                FantasyPoints = player.Points, 
                NBATeam = player.NBATeam, 
                FantasyTeam = player.FantasyTeam.Name 
            };
        }

        public async Task<PlayerDto> GetNextBestForecastedPlayerPresenter()
        {
            _logger.LogInformation("Get next best forecasted for presenter");
            return await _ctx.Players
                .Where(p => p.FantasyTeam.Name == "Free Agents")
                .OrderByDescending(p => p.FantasyPointsPredictedAverage)
                .Select(p => new PlayerDto() { Id = p.Id, Name = p.Name, Position = p.Position, FantasyPoints = p.FantasyPointsPredictedAverage, NBATeam = p.NBATeam, FantasyTeam = p.FantasyTeam.Name })
                .Take(1)
                .FirstOrDefaultAsync();
        }
    }
}
