using System;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private  Player[] players = new Player[2];
        private const int Player1Index = 0;
        private const int Player2Index = 1;
        
        public TennisGame1(string player1Name, string player2Name)
        {
            this.players[Player1Index]= new Player(player1Name);
            this.players[Player2Index]= new Player(player2Name);
        }

        public void WonPoint(string playerName)
        {
            var player = GetPlayerByName(playerName);
            player.WinPoint();
        }
        
        public string GetScore()
        {
            int player1Score = players[Player1Index].Score;
            int player2Score = players[Player2Index].Score;
            var scoreManager = new ScoreManager();
            return scoreManager.CalculateScore(player1Score, player2Score);
        }
        
        
        
        //get player by Name from players array
        private Player GetPlayerByName(string playerName)
        {
            foreach (var player in players)
            {
                if (player.Name == playerName)
                {
                    return player;
                }
            }
            return null;
        }
    }
}

