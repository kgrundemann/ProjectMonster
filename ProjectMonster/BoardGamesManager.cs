using static System.Console;
using System.Data.SqlClient;


namespace ProjectMonster;

public class BoardGamesManager
{
    private readonly List<BoardGame> _boardGames;

    public BoardGamesManager()
    {
        _boardGames = new List<BoardGame>()
        {
            new BoardGame("Everdell", 1, 6, 120),
            new BoardGame("Clank", 2, 6, 100),
            new BoardGame("Robinson Crusoe", 1, 4, 120)
        };
    }
    // Display
    public void DisplayGameList()
    {
        foreach (var game in _boardGames)
        {
            WriteLine(game.ToString());
        }
    }
    // Add
    public void AddGameToList()
    {
        Write("Enter the name of the game: ");
        const string? name = (string?)null;

        Write("Enter the minimum number of players: ");
        var minPlayers = Convert.ToInt32(ReadLine());

        Write("Enter the maximum number of players: ");
        var maxPlayers = Convert.ToInt32(ReadLine());

        Write("Enter the play time (in minutes): ");
        var playTime = Convert.ToInt32(ReadLine());

        _boardGames.Add(new BoardGame(name, minPlayers, maxPlayers, playTime));

        WriteLine("The board game has been added to the list.");
    }
    // Update
    public void UpdateGame()
    {
        Write("Enter the name of the game to update: ");
        var name = ReadLine();

        var gameToUpdate = _boardGames.Find(game => game.Name == name);

        if (gameToUpdate != null)
        {
            Write("Enter the new name of the game: ");
            var newName = ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                gameToUpdate.Name = newName;
            }

            Write("Enter the new minimum number of players: ");
            var newMinPlayers = ReadLine();
            if (!string.IsNullOrEmpty(newMinPlayers))
            {
                var minPlayers = Convert.ToInt32(newMinPlayers);
                gameToUpdate.MinNumPlayers = minPlayers;
            }

            Write("Enter the new maximum number of players: ");
            var newMaxPlayers = ReadLine();
            if (!string.IsNullOrEmpty(newMaxPlayers))
            {
                var maxPlayers = Convert.ToInt32(newMaxPlayers);
                gameToUpdate.MaxNumPlayers = maxPlayers;
            }
            Write("Enter the new play time (in minutes): ");
            var newPlayTime = ReadLine();
            if (!string.IsNullOrEmpty(newPlayTime))
            {
                var playTime = Convert.ToInt32(newPlayTime);
                gameToUpdate.DurationInMinutes = playTime;
            }

            WriteLine("The board game has been updated.");
        }
        else
        {
            WriteLine("The board game could not be found in the list.");
        }
    }
    // Remove
    public void RemoveGameFromList()
    {
        Write("Enter the name of the game to remove: ");
        var name = ReadLine();

        var gameToRemove = _boardGames.Find(game => game.Name == name);

        if (gameToRemove != null)
        {
            _boardGames.Remove(gameToRemove);
            WriteLine("The board game has been removed from the list.");
        }
        else
        {
            WriteLine("The board game could not be found in the list.");
        }
    }
    // Searching
    public void SearchGameByName()
    {
        Write("Enter the name of the game to search for: ");
        var name = ReadLine()?.ToLower().Trim();

        if (string.IsNullOrWhiteSpace(name)) 
        {
            WriteLine("Please enter a valid game name.");
            return;
        }

        var matchingGames = _boardGames.FindAll(game =>
            !string.IsNullOrWhiteSpace(game.Name) && 
            game.Name.ToLower().Contains(name)
        );

        if (matchingGames.Count > 0)
        {
            WriteLine("Matching games:");
            foreach (var game in matchingGames)
                WriteLine(game.ToString());
        }
        else
        {
            WriteLine("No matching games found.");
        }
    }
}