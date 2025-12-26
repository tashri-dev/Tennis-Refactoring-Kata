using System.Collections.Generic;

namespace Tennis.Strategies;

public class GameScoreStrategyFactory
{
    private static Dictionary<int, IGameScoreStrategy> Scores;

    private GameScoreStrategyFactory()
    {
        Scores = new Dictionary<int, IGameScoreStrategy>
        {
            [(int)Constants.ScoreType.Love] = new LoveScoreStrategy(),
            [(int)Constants.ScoreType.Fifteen] = new FifteenScoreStrategy(),
            [(int)Constants.ScoreType.Thirty] = new ThirtyScoreStrategy(),
            [(int)Constants.ScoreType.Forty] = new FortyScoreStrategy(),
            [(int)Constants.ScoreType.Deuce] = new DeuceScoreStrategy(),
            [(int)Constants.ScoreType.Advantage] = new AdvantageOrWinScoreStrategy(),
        };
    }


    public static string GetPlayer1Score(int player1Score, int player2Score)
    {
        return Scores[player1Score].GetScore(player1Score, player2Score);
    }
   
    public static string GetPlayer2Score(int player1Score, int player2Score)
    {
        return Scores[player2Score].GetScore(player1Score, player2Score);
    }
    
    public static string GetAdvantageOrWinScore(int player1Score, int player2Score)
    {
        return Scores[(int)Constants.ScoreType.Advantage].GetScore(player1Score, player2Score);
    }

}