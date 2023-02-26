namespace ProjectMonster;

public class BoardGame
{
    public string? Name { get; set; }

    public int DurationInMinutes { get; set; }

    public int MinNumPlayers { get; set; }

    public int MaxNumPlayers { get; set; }

    public BoardGame(string? name, int minNumPlayers, int maxNumPlayers, int durationInMinutes)
    {
        Name = name;
        DurationInMinutes = durationInMinutes;
        MinNumPlayers = minNumPlayers;
        MaxNumPlayers = maxNumPlayers;
    }

    public override string ToString()
    {
        return $"Title: {Name} - {MinNumPlayers}-{MaxNumPlayers} players - {DurationInMinutes} minutes";
    }
}