using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Drafter.Configuration
{
    public class ScoringConfig
    {
        public double Point { get; set; }
        public double Assist { get; set; }
        public double OffensiveRebound { get; set; }
        public double DefensiveRebound { get; set; }
        public double Block { get; set; }
        public double Steal { get; set; }
        public double Turnover { get; set; }
        public double DoubleDouble { get; set; }
        public double TripleDouble { get; set; }
        public double QuadrupleDouble { get; set; }
        public double FGA { get; set; }
        public double FGM { get; set; }
        public double FTA { get; set; }
        public double FTM { get; set; }
        public double ThreePM { get; set; }
    }
}
