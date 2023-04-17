using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
  public class FantasyTeam
  {
    public int Id { get; set; }
    public User Owner { get; set; }
    public ICollection<Player> Players { get; set; }
  }
}
