using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string NBATeam { get; set; }
        public decimal Points { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
        public DateTime DraftTime { get; set; }
        public int DraftPosition { get; set; }
        //public NBATeam NBATeam { get; set } NEED TO IMPLEMENT THIS TO SEE TEAMS AND DEPTH CHARTS

        public static Player FromCsv(string csvLine, FantasyTeam freeAgentTeam)
        {
            string[] values = csvLine.Split(',');
            Player player = new Player();
            player.Rank = Convert.ToInt16(values[0]);
            player.Name = values[1];
            player.Position = values[2];
            player.NBATeam = values[4];
            player.Points = Convert.ToDecimal(values[29]);
            player.FantasyTeam = freeAgentTeam;
            return player;
        }
    }
}
