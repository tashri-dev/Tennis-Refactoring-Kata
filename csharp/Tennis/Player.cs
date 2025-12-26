namespace Tennis;

public class Player(string name)
{
    public string Name { get; } = name;
    public int Score { get; private set; } = 0;
    public string Result { get; set; }

    public void WinPoint()
    {
        Score++;
    }
}