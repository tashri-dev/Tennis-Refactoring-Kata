using System;

namespace Tennis;

public class ScoreManager
{
    public string CalculateScore(Player firstPlayer, Player secondPlayer)
    {
        var player1Point = firstPlayer.Score;
        var player2Point = secondPlayer.Score;

        if (IsWin(player1Point, player2Point))
            return GetWinnerPlayer(player1Point, player2Point);
        if (IsAdvantage(player1Point, player2Point))
            return GetAdvantagePlayer(player1Point, player2Point);
        if (IsDeuce(player1Point, player2Point))
            return Constants.Scores.Deuce;
        if (IsDraw(player1Point, player2Point))
            return GetScorePoint(player1Point) + Constants.Scores.All;

        return $"{GetScorePoint(player1Point)}-{GetScorePoint(player2Point)}";
    }

    private bool IsDeuce(int player1Point, int player2Point) =>
        player1Point == player2Point && player1Point > 2;


    private bool IsDraw(int player1Point, int player2Point) =>
        player1Point == player2Point && player1Point < 3;


    private bool IsWin(int player1Point, int player2Point) =>
        (player1Point >= Constants.Scores.WinScore || player2Point >= Constants.Scores.WinScore)
        && Math.Abs(player1Point - player2Point) >= Constants.Scores.MinDifferenceForWin;


    private string GetWinnerPlayer(int player1Point, int player2Point) =>
        player1Point > player2Point ? Constants.Scores.WinForPlayer1 : Constants.Scores.WinForPlayer2;

    private bool IsAdvantage(int player1Point, int player2Point) =>
        player1Point >= 3 && player2Point >= 3 && Math.Abs(player1Point - player2Point) == 1;


    private string GetAdvantagePlayer(int player1Point, int player2Point) =>
        player1Point > player2Point ? Constants.Scores.AdvantagePlayer1 : Constants.Scores.AdvantagePlayer2;


    private static string GetScorePoint(int score)
    {
        return score switch
        {
            0 => Constants.Scores.Love,
            1 => Constants.Scores.Fifteen,
            2 => Constants.Scores.Thirty,
            3 => Constants.Scores.Forty,
            _ => Constants.Scores.Deuce
        };
    }
}