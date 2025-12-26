using System;
using System.Collections.Generic;
using Tennis.Strategies;

namespace Tennis;

//todo: fix the miss of the calculations with delgates or startegy pattern
public class ScoreManager
{
    private static Dictionary<int, IGameScoreStrategy> Scores;

    public ScoreManager()
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

    public string CalculateScore(int player1Score, int player2Score)
    {
        if (player1Score == player2Score)
        {
            return CalculateDrawScore(player1Score, player2Score);
        }

        if (player1Score >= Constants.Scores.WinScore || player2Score >= Constants.Scores.WinScore)
        {
            return Scores[(int)Constants.ScoreType.Advantage].GetScore(player1Score, player2Score);
        }

        return AddScores(player1Score, player2Score);
    }

    private string CalculateDrawScore(int player1Score, int player2Score)
    {
        string score = Scores[player1Score].GetScore(player1Score, player2Score);
        return player1Score < 3 ? score + Constants.Scores.All : score;
    }


    private string AddScores(int player1score, int player2score)
    {
        return Scores[player1score].GetScore(player1score, player2score) + "-" +
               Scores[player2score].GetScore(player1score, player2score);
    }
}