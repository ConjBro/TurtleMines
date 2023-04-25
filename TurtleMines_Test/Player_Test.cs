using TurtleMines;

namespace TurtleMines_Test;

public class PlayerTest
{
    private readonly List<IPosition> _moves;
    private readonly Board _board;
    
    public PlayerTest()
    {
        _moves = new TestData().Moves;
        _board = new TestData().Board;
    }

    [Fact]
    public void Move()
    {
        _board.Setup();
        var startingPosition = new Position(_board.StartLocation.X, _board.StartLocation.Y, _board.StartDirection);
        var player = new Player(startingPosition);

        foreach (var move in _moves)
        {
            player.Move(_board, move);
            
            Assert.Equal(move.X, player.Position.X);
            Assert.Equal(move.Y, player.Position.Y);
            Assert.Equal(move.Direction, player.Position.Direction);
        }
    }
}