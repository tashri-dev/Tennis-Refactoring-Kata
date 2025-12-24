namespace Tennis;

public class ScoreManager
{
    public string CalculateScore(int player1Score, int player2Score)
    {
        string score = "";
        var tempScore = 0;
        if (player1Score == player2Score)
        {
            score = CalculateDrawScore(player1Score);
        }
        if (player1Score >= 4 || player2Score >= 4)
        {
            var minusResult = player1Score - player2Score;
            if (minusResult == 1) score = Constants.Scores.AdvantagePlayer1;
            else if (minusResult == -1) score = Constants.Scores.AdvantagePlayer2;
            else if (minusResult >= 2) score = Constants.Scores.WinForPlayer1;
            else score = Constants.Scores.WinForPlayer2;
        }
        else
        {
            for (var i = 1; i < 3; i++)
            {
                if (i == 1) tempScore = player1Score;
                else
                {
                    score += "-";
                    tempScore = player2Score;
                }

                switch (tempScore)
                {
                    case 0:
                        score += Constants.Scores.Love;
                        break;
                    case 1:
                        score += Constants.Scores.Fifteen;
                        break;
                    case 2:
                        score += Constants.Scores.Thirty;
                        break;
                    case 3:
                        score += Constants.Scores.Forty;
                        break;
                }
            }
        }

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
}