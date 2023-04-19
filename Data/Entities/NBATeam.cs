using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
  public class NBATeam
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Player> Players { get; set; }
  }
}
