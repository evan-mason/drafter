using Drafter.Data.Entities;

namespace Drafter.Data
{
    public interface IDrafterRepository
    {
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<Player> GetAllFreeAgentPlayers();
        IEnumerable<Player> GetTimeline();
        IEnumerable<Player> GetPlayerByPosition(string position);
        IEnumerable<Player> GetPlayerByName(string name);
        IEnumerable<FantasyTeam> GetMyTeams(int userId);
        IEnumerable<Pick> GetPicks();
        Pick GetNextPick();
        void DraftPlayer(int id, int teamId);
        void UndraftPlayer(int id);
        bool SaveAll();
        //DEBUG METHOD REMOVE LATER
        void CreateKevy();
    }
}