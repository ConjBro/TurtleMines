namespace TurtleMines;

public class Player : IPlayer
{
    public Position Position { get; set; }

    public Player(IPosition startingPosition)
    {
        Position = new Position(startingPosition.X, startingPosition.Y, startingPosition.Direction);
    }

    public void Move(Board board, IPosition position)
    {
        Position.X = position.X;
        Position.Y = position.Y;
        Position.Direction = position.Direction;

        switch (board.CheckMove(position))
        {
            case GameObjectTypes.EmptySquare:
                Console.WriteLine("> Success!");
                break;
            case GameObjectTypes.Mine:
                Console.WriteLine("> Mine hit!");
                break;
            case GameObjectTypes.ExitLocation:
                Console.WriteLine("> Exit location reached!");
                break;
        }
    }
}