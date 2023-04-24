using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
    public class Pick
    {
        public int Id { get; set; }
        public int PickNumber { get; set; }
        public DateTime PickTakenTime { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
    }
}
