using System;
using System.Collections.Generic;
using Tennis.Strategies;

namespace Tennis;

//todo: fix the miss of the calculations with delgates or startegy pattern
public class ScoreManager
{

    public ScoreManager()
    {
      
    }

    public string CalculateScore(int player1Score, int player2Score)
    {
        if (player1Score == player2Score)
        {
            return CalculateDrawScore(player1Score, player2Score);
        }

        if (player1Score >= Constants.Scores.WinScore || player2Score >= Constants.Scores.WinScore)
        {
            return GameScoreStrategyFactory.GetAdvantageOrWinScore(player1Score, player2Score);
        }

        return GameScoreStrategyFactory.GetPlayer1Score(player1Score, player2Score) + "-" +
               GameScoreStrategyFactory.GetPlayer2Score(player1Score, player2Score);
    }

    private string CalculateDrawScore(int player1Score, int player2Score)
    {
        string score = GameScoreStrategyFactory.GetPlayer1Score(player1Score, player2Score);
        return player1Score < 3 ? score + Constants.Scores.All : score;
    }
}



