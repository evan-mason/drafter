using Drafter.Data.Entities;
using Drafter.ViewModels;

namespace Drafter.Data
{
    public interface IDrafterRepository
    {
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<PlayerDto> GetAllPlayersDashboard();

        Task<IEnumerable<PlayerDto>> GetMyPlayersDashboard(string userName);
        Task<IEnumerable<Player>> GetAllFreeAgentPlayers();
        Task<IEnumerable<Player>> GetTimeline();
        IEnumerable<Player> GetPlayerByPosition(string position);
        IEnumerable<Player> GetPlayerByName(string name);
        Task<IEnumerable<FantasyTeam>> GetMyTeam(string userId);
        IEnumerable<Pick> GetPicks();
        Pick GetNextPick();
        Task DraftPlayer(int id, string Name);
        Task UndraftPlayer(int id);
        bool SaveAll();
        Task CreateFantasyTeam(FantasyTeam? model, string? username);
        Draft GetDraftSettings();
        public void GenerateDraft();
        public Task CreateDraft(Draft newDraft, string username);
    }
}