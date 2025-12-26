using System.Diagnostics;

namespace Tennis.Strategies;

public interface IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score);
}

public class LoveScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return Constants.Scores.Love;
    }
}

public class FifteenScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return Constants.Scores.Fifteen;
    }
}

public class ThirtyScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return Constants.Scores.Thirty;
    }
}

public class FortyScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return player1Score == player2Score ? Constants.Scores.Deuce : Constants.Scores.Forty;
    }
}

public class DeuceScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return Constants.Scores.Deuce;
    }
}

public class AdvantageOrWinScoreStrategy() : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        var minusResult = player1Score - player2Score;
        return minusResult switch
        {
            1 => Constants.Scores.AdvantagePlayer1,
            -1 => Constants.Scores.AdvantagePlayer2,
            >= Constants.Scores.MinDifferenceForWin => Constants.Scores.WinForPlayer1,
            _ => Constants.Scores.WinForPlayer2
        };
    }
}