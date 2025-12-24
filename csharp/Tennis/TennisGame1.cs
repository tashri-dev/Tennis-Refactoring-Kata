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
            string score = "";
            var tempScore = 0;
            if (player1Score== player2Score)
            {
                switch (player1Score)
                {
                    case 0:
                        score = Constants.Scores.Love_All;
                        break;
                    case 1:
                        score = Constants.Scores.Fifteen_All;
                        break;
                    case 2:
                        score = Constants.Scores.Thirty_All;
                        break;
                    default:
                        score = Constants.Scores.Deuce;
                        break;

                }
            }
            else if (player1Score >= 4 || player2Score >= 4)
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
                    else { score += "-"; tempScore = player2Score; }
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

