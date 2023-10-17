using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
    public class PlayerDto // USED SO WE DON'T FETCH THE ENTIRE GALAXY
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string NBATeam { get; set; }
        public double FantasyPoints { get; set; }
        public string FantasyTeam { get; set; }
        public string PlayerPictureId { get; set; }
    }
}
