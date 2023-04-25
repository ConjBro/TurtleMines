using TurtleMines;

namespace TurtleMines_Test;

public class BoardTest
{
    private readonly IBoardConfiguration _gameSettings;

    public BoardTest()
    {
        var testData = new TestData();
        _gameSettings = testData.GameSettings;
    }

    [Fact]
    public void Setup()
    {
        var board = new Board(_gameSettings);

        Assert.Equal(_gameSettings.Size, board.Size);
        Assert.Equal(_gameSettings.StartLocation, board.StartLocation);
        Assert.Equal(_gameSettings.StartDirection, board.StartDirection);
        Assert.Equal(_gameSettings.ExitLocation, board.ExitLocation);
        Assert.Equal(_gameSettings.Mines, board.Mines);
        
        Assert.Null(board.Squares);
        board.Setup();
        Assert.NotNull(board.Squares);
        
        Assert.Equal(_gameSettings.Mines.ElementAt(0).X, board.Squares[1,1].X);
        Assert.Equal(_gameSettings.Mines.ElementAt(0).Y, board.Squares[1,1].Y);
        Assert.Equal(_gameSettings.Mines.ElementAt(0).Type, board.Squares[1,1].Type);
        Assert.Equal(_gameSettings.Mines.ElementAt(1).X, board.Squares[2,1].X);
        Assert.Equal(_gameSettings.Mines.ElementAt(1).Y, board.Squares[2,1].Y);
        Assert.Equal(_gameSettings.Mines.ElementAt(1).Type, board.Squares[2,1].Type);
        Assert.Equal(_gameSettings.Mines.ElementAt(2).X, board.Squares[3,1].X);
        Assert.Equal(_gameSettings.Mines.ElementAt(2).Y, board.Squares[3,1].Y);
        Assert.Equal(_gameSettings.Mines.ElementAt(2).Type, board.Squares[3,1].Type);
        Assert.Equal(_gameSettings.StartLocation.X, board.Squares[0,0].X);
        Assert.Equal(_gameSettings.StartLocation.Y, board.Squares[0,0].Y);
        Assert.Equal(_gameSettings.StartLocation.Type, board.Squares[0,0].Type);
        Assert.Equal(_gameSettings.ExitLocation.X, board.Squares[4,3].X);
        Assert.Equal(_gameSettings.ExitLocation.Y, board.Squares[4,3].Y);
        Assert.Equal(_gameSettings.ExitLocation.Type, board.Squares[4,3].Type);
    }

    [Fact]
    public void Board_IsSquareOccupied()
    {
        var validMove = new Position(0,1,Directions.East); 
        var invalidMove = new Position(1,1,Directions.East); 
        var board = new Board(_gameSettings);
        board.Setup();
        
        Assert.False(board.IsSquareOccupied(validMove));
        Assert.True(board.IsSquareOccupied(invalidMove));
    }

    [Fact]
    public void CheckMove()
    {
        var board = new Board(_gameSettings);
        board.Setup();
        
        var validMove = new Position(0,1,Directions.East);
        var validMoveResult = board.CheckMove(validMove);
        Assert.Equal(GameObjectTypes.EmptySquare, validMoveResult);
        
        var mineMove = new Position(1,1,Directions.East);
        var mineMoveResult = board.CheckMove(mineMove);
        Assert.Equal(GameObjectTypes.Mine, mineMoveResult);

        var winningMove = new Position(4,3, Directions.East);
        var winningMoveResult = board.CheckMove(winningMove);
        Assert.Equal(GameObjectTypes.ExitLocation, winningMoveResult);
        
        var invalidMove = new Position(-1,-1,Directions.East);
        Assert.Throws<IndexOutOfRangeException>(() => board.CheckMove(invalidMove));
    }
}