using System;

namespace Tennis;

public class ScoreManager
{
    public string CalculateScore(int player1Score, int player2Score)
    {
        string score = "";
        var tempScore = 0;
        if (player1Score == player2Score)
        {
            return CalculateDrawScore(player1Score);
        }
        if (player1Score >= 4 || player2Score >= 4)
        {
            return CheckResult(player1Score, player2Score);
        }
        return AddScores(player1Score, player2Score);
    }

    private string CheckResult(int player1Score, int player2Score)
    {
        string score;
        var minusResult = player1Score - player2Score;
        if (minusResult == 1) score = Constants.Scores.AdvantagePlayer1;
        else if (minusResult == -1) score = Constants.Scores.AdvantagePlayer2;
        else if (minusResult >= 2) score = Constants.Scores.WinForPlayer1;
        else score = Constants.Scores.WinForPlayer2;
        return score;
    }


    private string CalculateDrawScore(int playerScore)
    {
        string score = playerScore switch
        {
            0 => Constants.Scores.Love_All,
            1 => Constants.Scores.Fifteen_All,
            2 => Constants.Scores.Thirty_All,
            _ => Constants.Scores.Deuce
        };
        return score;
    }
    
    
    private string AddScores(int player1score, int player2score)
    {
        string score = "";
        for (var i = 1; i < 3; i++)
        {
            var tempScore = 0;
            if (i == 1) tempScore = player1score;
            else
            {
                score += "-";
                tempScore = player2score;
            }
           
            score += tempScore switch
            {
                0 => Constants.Scores.Love,
                1 => Constants.Scores.Fifteen,
                2 => Constants.Scores.Thirty,
                3 => Constants.Scores.Forty
            };

        }

        return score;
    }
}