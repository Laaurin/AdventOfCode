namespace Day_24;

public class Solution
{
    private Blizzard[] _blizzards;
    private char[,] _grid;
    private HashSet<Player> _players;

    public Solution(Player player, Blizzard[] blizzards, char[,] grid)
    {
        _blizzards = blizzards;
        _grid = grid;
        _players = new HashSet<Player>();
        _players.Add(player);
        
        PrintGrid();
        Console.WriteLine();
    }

    public void Solve()
    {
        BlizzardUpdater blizzardUpdater = new BlizzardUpdater();
        PlayerUpdater playerUpdater = new PlayerUpdater();

        for (int j = 0; j < 18; j++)
        {
            var newPlayerList = new HashSet<Player>();
            for (int i = 0; i < _blizzards.Length; i++)
            {
                blizzardUpdater.update(_blizzards[i], _grid);
            }
            foreach (var player in _players)
            {
            }
        }
        PrintGrid();
    }

    public void PrintGrid()
    {
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                Console.Write(_grid[i,j]);
            }

            Console.WriteLine();
        }
    }
}