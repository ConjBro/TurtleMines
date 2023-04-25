using TurtleMines;

namespace TurtleMines_Test;

public class TestData
{
    public readonly IBoardConfiguration GameSettings;
    public readonly Board Board;
    public readonly List<IPosition> Moves;
    
    public TestData()
    {
        GameSettings = new GameSettings
        {
            Size = new []{5,4},
            StartLocation = new Square{X = 0, Y = 0, Type = GameObjectTypes.StartLocation},
            ExitLocation = new Square{X = 4, Y = 3, Type = GameObjectTypes.ExitLocation},
            Mines = new List<IGameObject>
            {
                new Square{X = 1, Y = 1, Type = GameObjectTypes.Mine}, 
                new Square{X = 2, Y = 1, Type = GameObjectTypes.Mine}, 
                new Square{X = 3, Y = 1, Type = GameObjectTypes.Mine} 
            },
            StartDirection = Directions.South
        };

        Board = new Board(GameSettings);

        Moves = new List<IPosition>
        {
            new Position(1, 0, Directions.East),
            new Position(2, 0, Directions.East),
            new Position(3, 0, Directions.East),
            new Position(4, 0, Directions.East),
            new Position(4, 1, Directions.South),
            new Position(4, 2, Directions.South),
            new Position(4, 3, Directions.South),
        };
    }
}