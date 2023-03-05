using Microsoft.VisualBasic;

namespace Day_24;

public class Initializer
{
    private Blizzard[] _blizzards;
    private char[,] _grid;
    private Player _player;
    private int _height;
    private int _width;
    private int _blizzardAmount;

    public Blizzard[] Blizzards => _blizzards;
    public char[,] Grid => _grid;

    public Player Player => _player;

    public Initializer()
    {
        _blizzardAmount = 0;
        _height = 0;
        _player = new Player();
        
        init();
    }

    private void init()
    {
        StreamReader sr = new StreamReader(@"D:\code\C#\AdventOfCode 2022\Day_24\input.txt");

        string line = "";

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            _height++;
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] != '#' && line[i] != '.') _blizzardAmount++;
            }
        }

        _width = line.Length;

        _grid = new char[_height, _width];
        _blizzards = new Blizzard[_blizzardAmount];

        int blizzardsIdx = 0, y = 0;


        sr = new StreamReader(@"D:\code\C#\AdventOfCode 2022\Day_24\input.txt");

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            for (int i = 0; i < line.Length; i++)
            {
                var x = line.Length;
                _grid[y, i] = line[i];
                if (line[i] == '#' || line[i] == '.') continue;
                switch (line[i])
                {
                    case '<':
                        _blizzards[blizzardsIdx] = new Blizzard(i, y, Direction.Left);
                        break;
                    case '>':
                        _blizzards[blizzardsIdx] = new Blizzard(i, y, Direction.Right);
                        break;
                    case '^':
                        _blizzards[blizzardsIdx] = new Blizzard(i, y, Direction.Up);
                        break;
                    case 'v':
                        _blizzards[blizzardsIdx] = new Blizzard(i, y, Direction.Down);
                        break;
                }

                blizzardsIdx++;
            }
            y++;
        }
    }
}