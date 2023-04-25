namespace TurtleMines;

public class Game
{
    public readonly IBoardConfiguration GameSettings;
    public readonly List<IPosition> Moves;
    public Board Board;
    public IPlayer Player;

    public Game(IBoardConfiguration gameSettings, List<IPosition> moves)
    {
        GameSettings = gameSettings;
        Moves = moves;
    }

    public void Setup()
    {
        Board = new Board(GameSettings);
        Board.Setup();

        var startLocation = new Position(Board.StartLocation.X, Board.StartLocation.Y, Board.StartLocation.Type);
        Player = new Player(startLocation);
    }

    public void ExecuteMoves()
    {
        foreach (var move in Moves)
        {
            Player.Move(Board, move);
        }
    }
}