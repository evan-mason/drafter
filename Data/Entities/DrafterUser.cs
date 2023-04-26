using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.Data.Entities
{
  public class DrafterUser : IdentityUser
  {
    public FantasyTeam? FantasyTeam { get; set; } // LATER THIS WILL BE A COLLECTION OF TEAMS
  }
}
