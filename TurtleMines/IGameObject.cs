namespace TurtleMines;

public interface IGameObject : ICoordinates
{
    public Enum Type { get; set; }
}