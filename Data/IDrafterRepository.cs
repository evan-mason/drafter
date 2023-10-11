using Drafter.Data.Entities;
using Drafter.ViewModels;

namespace Drafter.Data
{
    public interface IDrafterRepository
    {
        IEnumerable<Player> GetAllPlayers();
        Task<IEnumerable<PlayerDto>> GetAllPlayersDashboard();
        Task<IEnumerable<PlayerDto>> GetFreePlayersDashboard();

        Task<IEnumerable<PlayerDto>> GetAllPlayersForecastedDashboard();
        Task<IEnumerable<PlayerDto>> GetFreePlayersForecastedDashboard();
        Task<IEnumerable<PlayerDto>> GetAllPlayersDashboardTotal();
        Task<IEnumerable<PlayerDto>> GetFreePlayersDashboardTotal();
        Task<IEnumerable<PlayerDto>> GetAllPlayersDashboardForecastedTotal();
        Task<IEnumerable<PlayerDto>> GetFreePlayersDashboardForecastedTotal();
        Task<Player> GetSelectedPlayerDashboard(int id); 
        Task<IEnumerable<PlayerDto>> GetMyPlayersDashboard(string userName);
        Task<IEnumerable<PlayerDto>> GetTeamPresenter(int drafterPlayerId);
        Task<String> GetTeamNamePresenter(int drafterPlayerId);
        Task<int> GetTotalTeamsPresenter();
        Task<IEnumerable<Player>> GetAllFreeAgentPlayers();
        Task<IEnumerable<Player>> GetTimeline();
        Task<IEnumerable<PlayerDto>> GetTimelineDashboard();
        IEnumerable<Player> GetPlayerByPosition(string position);
        IEnumerable<Player> GetPlayerByName(string name);
        Task<IEnumerable<FantasyTeam>> GetMyTeam(string userId);
        IEnumerable<Pick> GetPicks();
        Task<List<Pick>> GetPicksForDashboard();
        Task<List<Pick>> GetPicksForPresenter();
        Task<DateTime> GetLastPickTime();
        Pick GetNextPick();
        Task<Pick> GetNextPickDashboard();
        Task DraftPlayer(int id, string Name);
        Task<PlayerDto> DraftPlayerDashboard(PlayerDto playerDto, string userName);
        Task UndraftPlayer(int id);
        bool SaveAll();
        Task CreateFantasyTeam(FantasyTeam? model, string? username);
        Draft GetDraftSettings();
        public void GenerateDraft();
        public Task CreateDraft(Draft newDraft, string username);
    }
}