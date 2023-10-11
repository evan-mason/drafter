using Drafter.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
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

        public int PredictedGamesPL { get; set; }
        public double PredictedMinutes { get; set; }
        public double PredictedPoints { get; set; }
        public double PredictedTRB { get; set; }
        public double PredictedAST { get; set; }
        public double PredictedSTL { get; set; }
        public double PredictedBLK { get; set; }
        public double PredictedTOV { get; set; }
        public double PredictedFGM { get; set; }
        public double PredictedFGA { get; set; }
        public double PredictedThreePM { get; set; }
        public double PredictedThreePA { get; set; }
        public double PredictedFreeThrowPG { get; set; }
        public double PredictedFreeThrowPA { get; set; }
        public double PredictedORB { get; set; }
        public double PredictedDRB { get; set; }
        public double PredictedDD { get; set; }
        public double PredictedTD { get; set; }

        // Fantasy Points
        public double FantasyPointsAverage { get; set; }
        public double FantasyPointsTotal { get; set; }

        public double FantasyPointsPredictedAverage { get; set; }

        public double FantasyPointsPredictedTotal { get; set; }

        // Other useful columns
        public string PlayerPictureId { get; set; }

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
            player.Points = Convert.ToDouble(values[27]);
            player.minutesTotal = Convert.ToInt16(values[28]);
            player.FGMTotal = Convert.ToInt16(values[29]);
            player.FGATotal = Convert.ToInt16(values[30]);
            player.ThreePMTotal = Convert.ToInt16(values[31]);
            player.ThreePATotal = Convert.ToInt16(values[32]);
            player.TwoPMTotal = Convert.ToInt16(values[33]);
            player.TwoPATotal = Convert.ToInt16(values[34]);
            player.FreeThrowTotal = Convert.ToInt16(values[35]);
            player.FreeThrowPATotal = Convert.ToInt16(values[36]);
            player.ORBTotal = Convert.ToInt16(values[37]);
            player.DRBTotal = Convert.ToInt16(values[38]);
            player.TRBTotal = Convert.ToInt16(values[39]);
            player.ASTTotal = Convert.ToInt16(values[40]);
            player.STLTotal = Convert.ToInt16(values[41]);
            player.BLKTotal = Convert.ToInt16(values[42]);
            player.TOVTotal = Convert.ToInt16(values[43]);
            player.pointsTotal = Convert.ToInt16(values[44]);
            player.PlayerPictureId = values[45];
            player.PredictedGamesPL = Convert.ToInt16(values[46]);
            player.PredictedMinutes = Convert.ToDouble(values[47]);
            player.PredictedPoints = Convert.ToDouble(values[48]);
            player.PredictedTRB = Convert.ToDouble(values[49]);
            player.PredictedAST = Convert.ToDouble(values[50]);
            player.PredictedSTL = Convert.ToDouble(values[51]);
            player.PredictedBLK = Convert.ToDouble(values[52]);
            player.PredictedTOV = Convert.ToDouble(values[53]);
            player.PredictedFGM = Convert.ToDouble(values[54]);
            player.PredictedFGA = Convert.ToDouble(values[55]);
            player.PredictedThreePM = Convert.ToDouble(values[56]);
            player.PredictedThreePA = Convert.ToDouble(values[57]);
            player.PredictedFreeThrowPG = Convert.ToDouble(values[58]);
            player.PredictedFreeThrowPA = Convert.ToDouble(values[59]);
            player.PredictedORB = Convert.ToDouble(values[60]);
            player.PredictedDRB = Convert.ToDouble(values[61]);
            player.PredictedDD = Convert.ToDouble(values[62]);
            player.PredictedTD = Convert.ToDouble(values[63]);
            if (player.PredictedGamesPL > 0 && player.PredictedDD > 0)
            {
                player.PredictedDD = Math.Round(player.PredictedDD / player.PredictedGamesPL, 4); ;
            }
            if (player.PredictedGamesPL > 0 && player.PredictedTD > 0)
            {
                player.PredictedTD = Math.Round(player.PredictedTD / player.PredictedGamesPL, 4); ;
            }
            //player.DDTotal = Convert.ToInt16(values[49]);
            //player.TDTotal = Convert.ToInt16(values[50]);
            //player.QDTotal = Convert.ToInt16(values[51]);
            player.FantasyPointsTotal = getFantasyPoints(player, scoringConfig);
            if (player.FantasyPointsTotal == 0)
            {
                player.FantasyPointsAverage = 0;
            }
            else
            {
                player.FantasyPointsAverage = Math.Round(player.FantasyPointsTotal / player.GamesPL, 4);
            }
            player.FantasyPointsPredictedAverage = Math.Round(getFantasyPointsPrediction(player, scoringConfig), 4);
            player.FantasyPointsPredictedTotal = Math.Round(player.FantasyPointsPredictedAverage * player.PredictedGamesPL, 4);
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

        public static double getFantasyPointsPrediction(Player player, IOptions<ScoringConfig> scoringConfig)
        {
            return (player.PredictedPoints * scoringConfig.Value.Point)
                + (player.PredictedAST * scoringConfig.Value.Assist)
                + (player.PredictedORB * scoringConfig.Value.OffensiveRebound)
                + (player.PredictedDRB * scoringConfig.Value.DefensiveRebound)
                + (player.PredictedBLK * scoringConfig.Value.Block)
                + (player.PredictedSTL * scoringConfig.Value.Steal)
                + (player.PredictedTOV * scoringConfig.Value.Turnover)
                + (player.PredictedFGM * scoringConfig.Value.FGM)
                + (player.PredictedFGA * scoringConfig.Value.FGA)
                + (player.PredictedFreeThrowPG * scoringConfig.Value.FTM)
                + (player.PredictedFreeThrowPA * scoringConfig.Value.FTA)
                + (player.PredictedThreePM * scoringConfig.Value.ThreePM)
                + (player.PredictedDD * scoringConfig.Value.DoubleDouble)
                + (player.PredictedTD * scoringConfig.Value.TripleDouble);
        }
    }
}
