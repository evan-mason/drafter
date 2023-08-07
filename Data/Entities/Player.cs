using Drafter.Configuration;
using Microsoft.Extensions.Options;
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
        public int Rank { get; set; } // THIS COULD POSSIBLY BE REMOVED, ALTHOUGH I WOULD LOVE A POINTS/TOTALPOINTS/ADP RANK
        public string Name { get; set; }
        //I RECKON THE BELOW IS A LIST OF POSITIONS, OR MAYBE POSITION IS A TYPE WITH FALSE/TRUE POSITION BOOLEANS? RIGHT NOW WE WILL JUST USE STATIC STRINGS
        public string Position { get; set; }
        public string NBATeam { get; set; }
        public FantasyTeam FantasyTeam { get; set; }
        public DateTime DraftTime { get; set; }
        public int DraftPosition { get; set; }
        public int Age { get; set; }
        public int GamesPL { get; set; }
        public int GamesStarted { get; set; }
        // Averages
        public double Points { get; set; }
        public double Minutes { get; set; }
        public double FGM { get; set; }
        public double FGA { get; set; }
        public double FGP { get; set; }
        public double ThreePM { get; set; }
        public double ThreePA { get; set; }
        public double ThreePP { get; set; }
        public double TwoPM { get; set; }
        public double TwoPA { get; set; }
        public double TwoPP { get; set; }
        public double FreeThrowPG { get; set; }
        public double FreeThrowPA { get; set; }
        public double FreeThrowPP { get; set; }
        public double ORB { get; set; }
        public double DRB { get; set; }
        public double TRB { get; set; }
        public double AST { get; set; }
        public double STL { get; set; }
        public double BLK { get; set; }
        public double TOV { get; set; }

        // Totals

        public int pointsTotal { get; set; }
        public int minutesTotal { get; set; }
        public int FGMTotal { get; set; }
        public int FGATotal { get; set; }
        public int ThreePMTotal { get; set; }
        public int ThreePATotal { get; set; }
        public int TwoPMTotal { get; set; }
        public int TwoPATotal { get; set; }
        public int FreeThrowTotal { get; set; }
        public int FreeThrowPATotal { get; set; }
        public int ORBTotal { get; set; }
        public int DRBTotal { get; set; }
        public int TRBTotal { get; set; }
        public int ASTTotal { get; set; }
        public int STLTotal { get; set; }
        public int BLKTotal { get; set; }
        public int TOVTotal { get; set; }        

        // Forecast to complete

        // Fantasy Points
        public double FantasyPointsAverage { get; set; }
        public double FantasyPointsTotal { get; set; }

        //public NBATeam NBATeam { get; set } NEED TO IMPLEMENT THIS TO SEE TEAMS AND DEPTH CHARTS

        public static Player FromCsv(string csvLine, FantasyTeam freeAgentTeam, IOptions<ScoringConfig> scoringConfig)
        {
            string[] values = csvLine.Split(',');
            Player player = new Player();
            player.Rank = Convert.ToInt16(values[0]);
            player.Name = values[1];
            player.Position = values[2];
            player.Age = Convert.ToInt16(values[3]);
            player.NBATeam = values[4];
            player.GamesPL = Convert.ToInt16(values[5]);
            player.GamesStarted = Convert.ToInt16(values[6]);
            player.Minutes = Convert.ToDouble(values[7]);
            player.FGM = Convert.ToDouble(values[8]);
            player.FGA = Convert.ToDouble(values[9]);
            player.FGP = Convert.ToDouble(values[10]);
            player.ThreePM = Convert.ToDouble(values[11]);
            player.ThreePA = Convert.ToDouble(values[12]);
            player.ThreePP = Convert.ToDouble(values[13]);
            player.TwoPM = Convert.ToDouble(values[14]);
            player.TwoPA = Convert.ToDouble(values[15]);
            player.TwoPP = Convert.ToDouble(values[16]);
            player.FreeThrowPG = Convert.ToDouble(values[17]);
            player.FreeThrowPA = Convert.ToDouble(values[18]);
            player.FreeThrowPP = Convert.ToDouble(values[19]);
            player.ORB = Convert.ToDouble(values[20]);
            player.DRB = Convert.ToDouble(values[21]);
            player.TRB = Convert.ToDouble(values[22]);
            player.AST = Convert.ToDouble(values[23]);
            player.STL = Convert.ToDouble(values[24]);
            player.BLK = Convert.ToDouble(values[25]);
            player.TOV = Convert.ToDouble(values[26]);
            player.BLK = Convert.ToDouble(values[27]);
            player.Points = Convert.ToDouble(values[29]);
            player.minutesTotal = Convert.ToInt16(values[30]);
            player.FGMTotal = Convert.ToInt16(values[31]);
            player.FGATotal = Convert.ToInt16(values[32]);
            player.ThreePMTotal = Convert.ToInt16(values[33]);
            player.ThreePATotal = Convert.ToInt16(values[34]);
            player.TwoPMTotal = Convert.ToInt16(values[35]);
            player.TwoPATotal = Convert.ToInt16(values[36]);
            player.FreeThrowTotal = Convert.ToInt16(values[37]);
            player.FreeThrowPATotal = Convert.ToInt16(values[38]);
            player.ORBTotal = Convert.ToInt16(values[39]);
            player.DRBTotal = Convert.ToInt16(values[40]);
            player.TRBTotal = Convert.ToInt16(values[41]);
            player.ASTTotal = Convert.ToInt16(values[42]);
            player.STLTotal = Convert.ToInt16(values[43]);
            player.BLKTotal = Convert.ToInt16(values[44]);
            player.TOVTotal = Convert.ToInt16(values[45]);
            player.pointsTotal = Convert.ToInt16(values[47]);
            //player.DDTotal = Convert.ToInt16(values[48]);
            //player.TDTotal = Convert.ToInt16(values[49]);
            //player.QDTotal = Convert.ToInt16(values[50]);
            player.FantasyPointsTotal = scoringConfig.Value.Point * player.Points;
            player.FantasyPointsTotal = getFantasyPoints(player, scoringConfig);
            player.FantasyPointsAverage = player.FantasyPointsTotal / player.GamesPL;
            player.FantasyTeam = freeAgentTeam;
            return player;
        }

        public static double getFantasyPoints(Player player, IOptions<ScoringConfig> scoringConfig)
        {
            return (player.pointsTotal * scoringConfig.Value.Point)
                + (player.ASTTotal * scoringConfig.Value.Assist)
                + (player.ORBTotal * scoringConfig.Value.OffensiveRebound)
                + (player.DRBTotal * scoringConfig.Value.DefensiveRebound)
                + (player.BLKTotal * scoringConfig.Value.Block)
                + (player.STLTotal * scoringConfig.Value.Steal)
                + (player.TOVTotal * scoringConfig.Value.Turnover)
                //+ (player.DDTotal * scoringConfig.Value.DoubleDouble)
                //+ (player.TDTotal * scoringConfig.Value.TripleDouble)
                //+ (player.QDTotal * scoringConfig.Value.QuadrupleDouble)
                + (player.FGMTotal * scoringConfig.Value.FGM)
                + (player.FGATotal * scoringConfig.Value.FGA)
                + (player.FreeThrowTotal * scoringConfig.Value.FTM)
                + (player.FreeThrowPATotal * scoringConfig.Value.FTA)
                + (player.ThreePMTotal * scoringConfig.Value.ThreePM);
        }
    }
}
