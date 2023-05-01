using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
    public class Draft
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DrafterUser Admin { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime StartTime { get; set; }
        public string DraftType { get; set; }
        public int Rounds { get; set; } // THIS ALSO IS NUMBER OF PLAYERS TECHNICALLY
        public IList<FantasyTeam> Teams { get; set; } // THE ORDER OF THIS COLLECTION IS THE PICK ORDER.
        public IList<Pick> Picks { get; set; }
    }
}
