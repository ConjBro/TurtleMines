using TurtleMines;

// Write the code for taking in files via commandline arguments (Easy)
Console.WriteLine("Hello, World!" + args);

if (args.Length != 2)
{
    Console.WriteLine("Not enough file paths were added to the commandline arguments. 2 are required (game-settings.json and moves.json)");
    Environment.Exit(1);
}
else
{
    var gameSettingsPath = args[0];
    var movesPath = args[1];
    
    var fileReader = new FileReader();
    var gameSettings = fileReader.DeserializeGameSettings(gameSettingsPath);
    var movesList = fileReader.DeserializeMoves(movesPath);

    var game = new Game(gameSettings, movesList);
    game.Setup();
    game.ExecuteMoves();
}


