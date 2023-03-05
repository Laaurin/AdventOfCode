using System.Diagnostics;

namespace Day_24;

public class BlizzardUpdater
{
    public void update(Blizzard blizzard, char[,] map)
    {
        updateMap(blizzard, map);
        switch (blizzard.Direction)
        {
            case Direction.Up:
                if (blizzard.Y == 1) blizzard.Y = map.GetLength(0) - 2;
                else blizzard.Y--;
                break;
            case Direction.Down:
                if (blizzard.Y == map.GetLength(0) - 2) blizzard.Y = 1;
                else blizzard.Y++;
                break;
            case Direction.Left:
                if (blizzard.X == 1) blizzard.X = map.GetLength(1) - 2;
                else blizzard.X--;
                break;
            case Direction.Right:
                if (blizzard.X == map.GetLength(1) - 2) blizzard.X = 1;
                else blizzard.X++;
                break;
        }
        updateMap2(blizzard, map);
    }

    public void updateMap(Blizzard blizzard, char[,] map)
    {
        if (Char.IsDigit(map[blizzard.Y, blizzard.X]))
        {
            if (map[blizzard.Y, blizzard.X] == '2') map[blizzard.Y, blizzard.X] = 'V';
            else map[blizzard.Y, blizzard.X]--;
        }
        else map[blizzard.Y, blizzard.X] = '.';
    }
    
    public void updateMap2(Blizzard blizzard, char[,] map)
    {
        if (Char.IsDigit(map[blizzard.Y, blizzard.X]))
        {
            map[blizzard.Y, blizzard.X]++;
        }
        else if(map[blizzard.Y, blizzard.X] == '.')
        {
            switch (blizzard.Direction)
            {
                case Direction.Down:
                    map[blizzard.Y, blizzard.X] = 'v';
                    break;
                case Direction.Up:
                    map[blizzard.Y, blizzard.X] = '^';
                    break;
                case Direction.Right:
                    map[blizzard.Y, blizzard.X] = '>';
                    break;
                case Direction.Left:
                    map[blizzard.Y, blizzard.X] = '<';
                    break;
            }
        }
        else
        {
            map[blizzard.Y, blizzard.X] = '2';
        }
    }
}