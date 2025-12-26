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
           var scoreManager = new ScoreManager();
           return scoreManager.CalculateScore(players[Player1Index], players[Player2Index]);
        }

       
        public void WonPoint(string playerName)
        {
            var player = GetPlayerByName(playerName);
            player.WinPoint();
            if (playerName == players[Player1Index].Name)
            {
                player1Point = player.Score;
            }
            else
            {
                player2Point = player.Score;
            }
        }

        private Player GetPlayerByName(string playerName)
        {
            return (playerName == players[Player1Index].Name)
                ? players[Player1Index]
                : players[Player2Index];
        }
      

    }
}

