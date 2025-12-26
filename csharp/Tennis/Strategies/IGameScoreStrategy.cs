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
        return player1Score == player2Score ? Constants.Scores.Deuce: Constants.Scores.Forty;
    }
}

public class DeuceScoreStrategy : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        return "Deuce";
    }
}

public class AdvantageOrWinScoreStrategy() : IGameScoreStrategy
{
    public string GetScore(int player1Score, int player2Score)
    {
        string score;
        var minusResult = player1Score - player2Score;
        if (minusResult == 1) score = Constants.Scores.AdvantagePlayer1;
        else if (minusResult == -1) score = Constants.Scores.AdvantagePlayer2;
        else if (minusResult >= 2) score = Constants.Scores.WinForPlayer1;
        else score = Constants.Scores.WinForPlayer2;
        return score;
    }
}
