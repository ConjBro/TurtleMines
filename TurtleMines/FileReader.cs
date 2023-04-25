using Newtonsoft.Json;

namespace TurtleMines;

public class FileReader
{
    public GameSettings? DeserializeGameSettings(string filePath)
    {
        using var streamReader = new StreamReader(filePath);
        var json = streamReader.ReadToEnd();
        
        return JsonConvert.DeserializeObject<GameSettings>(json);
    }

    public List<IPosition>? DeserializeMoves(string filePath)
    {
        using var moveReader = new StreamReader(filePath);
        var json = moveReader.ReadToEnd();
        
        return JsonConvert.DeserializeObject<List<IPosition>>(json);
    }
}