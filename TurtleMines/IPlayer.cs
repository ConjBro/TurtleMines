namespace TurtleMines;

public interface IPlayer
{
    public Position Position { get; set; }
    public void Move(Board board, IPosition position);
}