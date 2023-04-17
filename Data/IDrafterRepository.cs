using Drafter.Data.Entities;

namespace Drafter.Data
{
    public interface IDrafterRepository
    {
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<Player> GetPlayerByPosition(string position);
        IEnumerable<Player> GetPlayerByName(string name);
        bool SaveAll();
    }
}