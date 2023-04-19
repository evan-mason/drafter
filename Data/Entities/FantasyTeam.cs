using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
  public class FantasyTeam
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public User User { get; set; }
    [ForeignKey("FantasyTeamFK")]
    public ICollection<Player> Players { get; set; }
  }
}
