namespace Day_24;

public class Player
{
    private int _x;
    private int _y;

    public int X
    {
        get => _x;
        set => _x = value;
    }

    public int Y
    {
        get => _y;
        set => _y = value;
    }

    public Player(int x = 1, int y = 0)
    {
        _x = x;
        _y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }
        if (!(obj is Player))
        {
            return false;
        }
        return (this._x == ((Player)obj).X)
               && (this._y == ((Player)obj).Y);
    }
}