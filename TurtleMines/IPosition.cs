namespace TurtleMines;

public interface IPosition : ICoordinates
{
    public Enum Direction { get; set; }
}