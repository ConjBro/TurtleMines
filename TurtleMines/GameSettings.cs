namespace TurtleMines;

public class GameSettings : IBoardConfiguration
{
    public int[] Size { get; init; }

    public IGameObject StartLocation { get; init; }

    public IGameObject ExitLocation { get; init; }

    public List<IGameObject> Mines { get; init; }

    public Enum StartDirection { get; init; }
}