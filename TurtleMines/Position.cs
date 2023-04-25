namespace TurtleMines;

public class Position : IPosition
{
    public int X { get; set; }
    public int Y { get; set; }
    public Enum Direction { get; set; }
    
    public Position(int x, int y, Enum direction)
    {
        X = x;
        Y = y;
        Direction = direction;
    }
}