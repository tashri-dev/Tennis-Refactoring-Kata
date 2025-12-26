namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int player1Point;
        private int player2Point;
        
        Player[] players = new Player[2];
        private const int Player1Index = 0;
        private const int Player2Index = 1;
        public TennisGame2(string player1Name, string player2Name)
        {
            players[Player1Index] = new Player(player1Name);
            player1Point = players[Player1Index].Score;
            players[Player2Index] = new Player(player2Name);
            
        }

        public string GetScore()
        {
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
                    players[Player1Index].Result = Constants.Scores.Fifteen;
                if (player1Point == 2)
                    players[Player1Index].Result = Constants.Scores.Thirty;
                if (player1Point == 3)
                    players[Player1Index].Result = Constants.Scores.Forty;

                players[Player2Index].Result = Constants.Scores.Love;
                score = players[Player1Index].Result + "-" + players[Player2Index].Result;
            }
            if (player2Point > 0 && player1Point == 0)
            {
                if (player2Point == 1)
                    players[Player2Index].Result = Constants.Scores.Fifteen;
                if (player2Point == 2)
                    players[Player2Index].Result = Constants.Scores.Thirty;
                if (player2Point == 3)
                    players[Player2Index].Result = Constants.Scores.Forty;

                players[Player1Index].Result = Constants.Scores.Love;
                score = players[Player1Index].Result + "-" + players[Player2Index].Result;
            }

            if (player1Point > player2Point && player1Point < Constants.Scores.WinScore)
            {
                if (player1Point == 2)
                    players[Player1Index].Result = Constants.Scores.Thirty;
                if (player1Point == 3)
                    players[Player1Index].Result = Constants.Scores.Forty;
                if (player2Point == 1)
                    players[Player2Index].Result = Constants.Scores.Fifteen;
                if (player2Point == 2)
                    players[Player2Index].Result = Constants.Scores.Thirty;
                score = players[Player1Index].Result + "-" + players[Player2Index].Result;
            }
            if (player2Point > player1Point && player2Point < Constants.Scores.WinScore)
            {
                if (player2Point == 2)
                    players[Player2Index].Result = Constants.Scores.Thirty;
                if (player2Point == 3)
                    players[Player2Index].Result = Constants.Scores.Forty;
                if (player1Point == 1)
                    players[Player1Index].Result = Constants.Scores.Fifteen;
                if (player1Point == 2)
                    players[Player1Index].Result = Constants.Scores.Thirty;
                score = players[Player1Index].Result + "-" + players[Player2Index].Result;
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

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            player1Point++;
        }

        private void P2Score()
        {
            player2Point++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

