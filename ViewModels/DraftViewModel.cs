using Drafter.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drafter.ViewModels
{
    public class DraftViewModel
    {
        [Required]
        public string Name { get; set; }
        //public DateTime DateCreated { get; set; }
        //public DateTime StartTime { get; set; }
        [Required]
        public string DraftType { get; set; }
        [Required]
        public int Rounds { get; set; } // THIS ALSO IS NUMBER OF PLAYERS TECHNICALLY
    }
}
