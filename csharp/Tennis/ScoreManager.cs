namespace Tennis;

public abstract class ScoreManager
{
    public static string CalculateScore(Player firstPlayer, Player secondPlayer)
    {
           var player1Point = firstPlayer.Score;
            var player2Point = secondPlayer.Score;
            
        
        var score = "";
            if (player1Point == player2Point && player1Point < 3)
            {
                if (player1Point == 0)
                    score = Constants.Scores.Love;
                if (player1Point == 1)
                    score = Constants.Scores.Fifteen;
                if (player1Point == 2)
                    score = Constants.Scores.Thirty;
                score += Constants.Scores.All;
            }
            if (player1Point == player2Point && player1Point > 2)
                score = Constants.Scores.Deuce;

            if (player1Point > 0 && player2Point == 0)
            {
                if (player1Point == 1)
                   firstPlayer.Result = Constants.Scores.Fifteen;
                if (player1Point == 2)
                   firstPlayer.Result = Constants.Scores.Thirty;
                if (player1Point == 3)
                   firstPlayer.Result = Constants.Scores.Forty;

                secondPlayer.Result = Constants.Scores.Love;
                score =firstPlayer.Result + "-" + secondPlayer.Result;
            }
            if (player2Point > 0 && player1Point == 0)
            {
                if (player2Point == 1)
                    secondPlayer.Result = Constants.Scores.Fifteen;
                if (player2Point == 2)
                    secondPlayer.Result = Constants.Scores.Thirty;
                if (player2Point == 3)
                    secondPlayer.Result = Constants.Scores.Forty;

               firstPlayer.Result = Constants.Scores.Love;
                score =firstPlayer.Result + "-" + secondPlayer.Result;
            }

            if (player1Point > player2Point && player1Point < Constants.Scores.WinScore)
            {
                if (player1Point == 2)
                   firstPlayer.Result = Constants.Scores.Thirty;
                if (player1Point == 3)
                   firstPlayer.Result = Constants.Scores.Forty;
                if (player2Point == 1)
                    secondPlayer.Result = Constants.Scores.Fifteen;
                if (player2Point == 2)
                    secondPlayer.Result = Constants.Scores.Thirty;
                score =firstPlayer.Result + "-" + secondPlayer.Result;
            }
            if (player2Point > player1Point && player2Point < Constants.Scores.WinScore)
            {
                if (player2Point == 2)
                    secondPlayer.Result = Constants.Scores.Thirty;
                if (player2Point == 3)
                    secondPlayer.Result = Constants.Scores.Forty;
                if (player1Point == 1)
                   firstPlayer.Result = Constants.Scores.Fifteen;
                if (player1Point == 2)
                   firstPlayer.Result = Constants.Scores.Thirty;
                score =firstPlayer.Result + "-" + secondPlayer.Result;
            }

            if (player1Point > player2Point && player2Point >= 3)
            {
                score = Constants.Scores.AdvantagePlayer1;
            }

            if (player2Point > player1Point && player1Point >= 3)
            {
                score = Constants.Scores.AdvantagePlayer2;
            }

            if (player1Point >= 4 && player2Point >= 0 && (player1Point - player2Point) >= 2)
            {
                score = Constants.Scores.WinForPlayer1;
            }
            if (player2Point >= 4 && player1Point >= 0 && (player2Point - player1Point) >= 2)
            {
                score = Constants.Scores.WinForPlayer2;
            }
            return score;
    }
}