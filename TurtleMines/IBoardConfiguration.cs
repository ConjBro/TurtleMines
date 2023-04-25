namespace TurtleMines;

public interface IBoardConfiguration
{
    public int[] Size { get; }
    public IGameObject StartLocation { get; }
    public IGameObject ExitLocation { get; }
    public List<IGameObject> Mines { get; }
    public Enum StartDirection { get; }
}