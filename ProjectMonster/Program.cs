using ProjectMonster;
using static System.Console;


BoardGamesManager boardGameManager = new();

while (true)
{
    WriteLine("1. Display the list of board games");
    WriteLine("2. Add a new board game to the list");
    WriteLine("3. Update a board game in the list");
    WriteLine("4. Remove a board game from the list");
    WriteLine("5. Search for a board game by name");
    WriteLine("6. Save game list to file");
    WriteLine("7. Load game list to file");
    WriteLine("0. Exit the program");
    try
    {
        Write("Choose an option: ");
        var option = Convert.ToInt32(ReadLine());

        switch (option)
        {
            case 1:
                boardGameManager.DisplayGameList();
                break;

            case 2:
                boardGameManager.AddGameToList();
                break;

            case 3:
                boardGameManager.UpdateGame();
                break;

            case 4:
                boardGameManager.RemoveGameFromList();
                break;

            case 5:

                boardGameManager.SearchGameByName();
                break;

            case 6:
                boardGameManager.SaveGameListToFile();
                break;

            case 7:
                boardGameManager.LoadGameListFromFile();
                break;

            case 0:
                Environment.Exit(0);
                break;

            default:
                WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (FormatException)
    {
        WriteLine("Invalid input: please enter an integer.");
    }
}