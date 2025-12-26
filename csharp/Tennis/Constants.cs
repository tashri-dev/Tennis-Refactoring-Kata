namespace Tennis;

public class Constants
{
    public static class Scores
    {
        public const string All = "-All";
        public const string Love = "Love";
        public const string Fifteen = "Fifteen";
        public const string Thirty = "Thirty";
        public const string Forty = "Forty";
        public const string Deuce = "Deuce";
        public const string AdvantagePlayer1 = "Advantage player1";
        public const string AdvantagePlayer2 = "Advantage player2";
        public const string WinForPlayer1 = "Win for player1";
        public const string WinForPlayer2 = "Win for player2";
        
        public const int WinScore = 4;
        public const int MinDifferenceForWin = 2;
    }
    
    public enum ScoreType:byte
    {
        Love,
        Fifteen,
        Thirty,
        Forty,
        Deuce,
        Advantage, 
    }
}