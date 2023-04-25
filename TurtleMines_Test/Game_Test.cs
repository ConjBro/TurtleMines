using TurtleMines;

namespace TurtleMines_Test;

public class GameTest
{
    private readonly IBoardConfiguration _gameSettings;
    private readonly List<IPosition> _moves;
    
    public GameTest()
    {
        _gameSettings = new TestData().GameSettings;
        _moves = new TestData().Moves;
    }

    [Fact]
    public void Setup()
    {
        var game = new Game(_gameSettings, _moves);
        Assert.Null(game.Board);
        Assert.Null(game.Player);
        
        game.Setup();
        Assert.NotNull(game.Board);
        Assert.NotNull(game.Player);
        
        Assert.Equal(_gameSettings.StartLocation.X, game.Board.StartLocation.X);
        Assert.Equal(_gameSettings.StartLocation.Y, game.Board.StartLocation.Y);
        Assert.Equal(_gameSettings.StartDirection, game.Board.StartDirection);
    }

    [Fact]
    public void ExecuteMoves()
    {
        var game = new Game(_gameSettings, _moves);
        game.Setup();
        
        Assert.Equal(_moves.ElementAt(0).X, game.Moves.ElementAt(0).X);
        Assert.Equal(_moves.ElementAt(0).Y, game.Moves.ElementAt(0).Y);
        Assert.Equal(_moves.ElementAt(0).Direction, game.Moves.ElementAt(0).Direction);

        var movesMaxIndex = _moves.Count-1;
        Assert.Equal(_moves.ElementAt(movesMaxIndex).X, game.Moves.ElementAt(movesMaxIndex).X);
        Assert.Equal(_moves.ElementAt(movesMaxIndex).Y, game.Moves.ElementAt(movesMaxIndex).Y);
        Assert.Equal(_moves.ElementAt(movesMaxIndex).Direction, game.Moves.ElementAt(movesMaxIndex).Direction);

        game.ExecuteMoves();
        Assert.Equal(_gameSettings.ExitLocation.X, game.Player.Position.X);
        Assert.Equal(_gameSettings.ExitLocation.Y, game.Player.Position.Y);
    }
}