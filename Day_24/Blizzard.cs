namespace Day_24;

public class Blizzard
{
    private int _x;
    private int _y;
    private Direction _direction;

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

    public Direction Direction => _direction;

    public Blizzard(int x, int y, Direction direction)
    {
        this._x = x;
        this._y = y;
        this._direction = direction;
    }
}