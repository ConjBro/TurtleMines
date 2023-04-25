namespace TurtleMines;

public class Board : IBoardConfiguration
{
    public int[] Size { get; set; }
    public IGameObject StartLocation { get; set; }
    public IGameObject ExitLocation { get; set; }
    public List<IGameObject> Mines { get; set; }
    public Enum StartDirection { get; set; }
    
    public IGameObject[,] Squares;

    public Board(IBoardConfiguration boardConfiguration)
    {
        Size = boardConfiguration.Size;
        StartLocation = boardConfiguration.StartLocation;
        ExitLocation = boardConfiguration.ExitLocation;
        Mines = boardConfiguration.Mines;
        StartDirection = boardConfiguration.StartDirection;
    }

    public void Setup()
    {
        Squares = new IGameObject[Size[0],Size[1]];
        
        for (var i = 0; i < Size[0]; i++)
        {
            for (var j = 0; j < Size[1]; j++)
            {
                Squares[i,j] = new Square
                {
                    X = i, 
                    Y = j, 
                    Type = GameObjectTypes.EmptySquare
                };
            }
        }

        Squares[StartLocation.X, StartLocation.Y] = new Square
        {
            X = StartLocation.X,
            Y = StartLocation.Y,
            Type = GameObjectTypes.StartLocation
        };
        Squares[ExitLocation.X, ExitLocation.Y] = new Square
        {
            X = ExitLocation.X,
            Y = ExitLocation.Y,
            Type = GameObjectTypes.ExitLocation
        };

        foreach (var mine in Mines)
        {
            if (Squares[mine.X, mine.Y].Type.Equals(GameObjectTypes.EmptySquare))
            {
                Squares[mine.X, mine.Y] = new Square
                {
                    X = mine.X,
                    Y = mine.Y,
                    Type = GameObjectTypes.Mine
                };
            }
        }
    }

    public Enum CheckMove(IPosition position)
    {
        if (position.X > Size[0] || position.X < 0 || position.Y > Size[1] || position.Y < 0)
        {
            throw new IndexOutOfRangeException("Position index is out of range, please use valid coordinates.");
        }
        
        return IsSquareOccupied(position) 
            ? Squares[position.X, position.Y].Type 
            : GameObjectTypes.EmptySquare;
    }
    
    public bool IsSquareOccupied(IPosition position)
    {
        return !Squares[position.X, position.Y].Type.Equals(GameObjectTypes.EmptySquare);
    }
}