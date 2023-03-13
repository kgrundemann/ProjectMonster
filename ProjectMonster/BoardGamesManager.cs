using static System.Console;


namespace ProjectMonster;

public class BoardGamesManager
{
    private readonly List<BoardGame> _boardGames;

    public BoardGamesManager()
    {
        _boardGames = new List<BoardGame>();
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
        var name = ReadLine();

        
        Write("Enter the minimum number of players: ");
        int minPlayers;
        try
        {
             minPlayers = Convert.ToInt32(ReadLine());
        }
        catch (FormatException)
        {
            WriteLine("Invalid input: please enter an integer.");
            return;
        }
        Write("Enter the maximum number of players: ");
        int maxPlayers;
        try
        {
            maxPlayers = Convert.ToInt32(ReadLine());
        }
        catch (FormatException)
        {
            WriteLine("Invalid input: please enter an integer.");
            return;
        }

        Write("Enter the play time (in minutes): ");
        int durationInMinutes;
        try
        {
             durationInMinutes = Convert.ToInt32(ReadLine());
        }
        catch (FormatException)
        {
            WriteLine("Invalid input: please enter an integer.");
            return;
        }

        _boardGames.Add(new BoardGame(name, minPlayers, maxPlayers, durationInMinutes));

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
            try
            {
                var newMinPlayers = Convert.ToInt32(ReadLine());
                gameToUpdate.MinNumPlayers = newMinPlayers;
            }
            catch (FormatException)
            {
                WriteLine("Invalid input: please enter an integer.");
                return;
            }

            Write("Enter the new maximum number of players: ");
            try
            {
                var newMaxPlayers = Convert.ToInt32(ReadLine());
                gameToUpdate.MaxNumPlayers = newMaxPlayers;
            }
            catch (FormatException)
            {
                WriteLine("Invalid input: please enter an integer.");
                return;
            }

            Write("Enter the new play time (in minutes): ");
            try
            {
                var newDurationInMinutes = Convert.ToInt32(ReadLine());
                gameToUpdate.DurationInMinutes = newDurationInMinutes;
            }
            catch (FormatException)
            {
                WriteLine("Invalid input: please enter an integer.");
                return;
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
            WriteLine("Please enter a game name.");
            return;
        }

        var matchingGame = _boardGames.Find(game =>
            !string.IsNullOrWhiteSpace(game.Name) && 
            game.Name.ToLower().Contains(name)
        );

        WriteLine(matchingGame != null ? $"Matching game: {matchingGame}" : "No matching game found.");
    }

    private const string FilePath = @"C:\Users\Krzysiek\source\repos\ProjectMonster\BoardGames.csv";

    public void SaveGameListToFile()
    {
        try
        {
            using (var gameList = new StreamWriter(FilePath))
            {
                foreach (var game in _boardGames)
                {
                    gameList.WriteLine($"{game.Name},{game.MinNumPlayers},{game.MaxNumPlayers},{game.DurationInMinutes}");
                }
            }

            WriteLine($"Game list has been saved to file: {FilePath}");
        }
        catch (IOException ex)
        {
            WriteLine($"Error occurred while saving the game list to file: {ex.Message}");
        }
    }

    public void LoadGameListFromFile()
    {
        try
        {
            using (var gameList = new StreamReader(FilePath))
            {
                var newGameList = new List<BoardGame>();
                while (gameList.ReadLine() is { } line)
                {
                    var fields = line.Split(',');
                    var name = fields[0];
                    var minPlayers = int.Parse(fields[1]);
                    var maxPlayers = int.Parse(fields[2]);
                    var durationInMinutes = int.Parse(fields[3]);
                    newGameList.Add(new BoardGame(name, minPlayers, maxPlayers, durationInMinutes));
                }
                _boardGames.Clear();
                _boardGames.AddRange(newGameList);
            }

            WriteLine($"Game list has been loaded from file: {FilePath}");
        }
        catch (IOException ex)
        {
            WriteLine($"Error occurred while loading the game list from file: {ex.Message}");
        }
    }
}

