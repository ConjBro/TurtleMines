using Newtonsoft.Json;
using TurtleMines;

namespace TurtleMines_Test;

public class FileReaderTest
{
    private readonly IBoardConfiguration? _gameSettings;
    private readonly List<IPosition>? _moves;
    
    public FileReaderTest()
    {
        try
        {
            using var gameSettingsReader = new StreamReader("../../../game-settings.json");
            var json = gameSettingsReader.ReadToEnd();
            _gameSettings = JsonConvert.DeserializeObject<GameSettings>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine("The 'game-settings' file could not be read:");
            Console.WriteLine(e.Message);
        }
        
        try
        {
            using var movesReader = new StreamReader("../../../moves.json");
            var json = movesReader.ReadToEnd();
            _moves = JsonConvert.DeserializeObject<List<IPosition>>(json);
        }
        catch (Exception e)
        {
            Console.WriteLine("The 'moves' file could not be read:");
            Console.WriteLine(e.Message);
        }
    }
    
    [Fact]
    public void DeserializeGameSettings()
    {
        const string filePath = "../../../game-settings.json";
        
        var fr = new FileReader();
        var deserializedObj = fr.DeserializeGameSettings(filePath);
        
        Assert.IsType<GameSettings>(deserializedObj);
        Assert.Equal(_gameSettings?.Size, deserializedObj.Size);
        Assert.Equal(_gameSettings?.StartLocation, deserializedObj.StartLocation);
        Assert.Equal(_gameSettings?.ExitLocation, deserializedObj.ExitLocation);
        Assert.Equal(_gameSettings?.Mines, deserializedObj.Mines);
        Assert.Equal(_gameSettings?.StartDirection, deserializedObj.StartDirection);
    }

    [Fact]
    public void DeserializeMoves()
    {
        const string filePath = "../../../moves.json";
        
        var fr = new FileReader();
        var moves = fr.DeserializeMoves(filePath);
        
        Assert.IsType<IPosition>(moves);
        Assert.NotEmpty(moves);
        
        for (var i = 0; i < moves.Count; i++)
        {
            Assert.Equal(_moves.ElementAt(i).X, moves.ElementAt(i).X);    
            Assert.Equal(_moves.ElementAt(i).Y, moves.ElementAt(i).Y);    
            Assert.Equal(_moves.ElementAt(i).Direction, moves.ElementAt(i).Direction);    
        }
    }
}