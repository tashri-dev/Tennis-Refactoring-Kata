namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
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
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = Constants.Scores.AdvantagePlayer1;
                else if (minusResult == -1) score = Constants.Scores.AdvantagePlayer2;
                else if (minusResult >= 2) score = Constants.Scores.WinForPlayer1;
                else score = Constants.Scores.WinForPlayer2;
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
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
    }
}

