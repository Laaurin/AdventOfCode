namespace Day_24;

public class Solution
{
    private Blizzard[] _blizzards;
    private char[,] _grid;
    private List<Player> _players;

    public Solution(Player player, Blizzard[] blizzards, char[,] grid)
    {
        _blizzards = blizzards;
        _grid = grid;
        _players = new List<Player> { player };
        PrintGrid(0, 0, _players.ToArray());
        Console.WriteLine();
    }

    public int Solve()
    {
        BlizzardUpdater blizzardUpdater = new BlizzardUpdater();
        PlayerUpdater playerUpdater = new PlayerUpdater();
        int minute = 0;
        while(true)
        {
            minute++;
            var newPlayerList = new List<Player>();
            for (int i = 0; i < _blizzards.Length; i++)
            {
                blizzardUpdater.update(_blizzards[i], _grid);
            }

            if (minute == 17)
            {
                var x = 0;
            }
            
            //moving player
            foreach (var player in _players)
            {
                //int x = player.X, y evtl später
                bool moved = false;
                if (_grid[player.Y, player.X + 1] == '.')
                {
                    newPlayerList.Add(new Player(player.X + 1, player.Y, player.Distace+1));
                    moved = true;
                }

                if (_grid[player.Y, player.X - 1] == '.')
                {
                    moved = true;
                    newPlayerList.Add(new Player(player.X - 1, player.Y, player.Distace+1));
                }

                if (_grid[player.Y + 1, player.X] == '.')
                {
                    newPlayerList.Add(new Player(player.X, player.Y + 1, player.Distace+1));
                    moved = true;
                }

                if (player.Y != 0 && _grid[player.Y - 1, player.X] == '.')
                {
                    moved = true;
                    newPlayerList.Add(new Player(player.X, player.Y - 1, player.Distace+1));
                }

                if (!moved) newPlayerList.Add(new Player(player.X, player.Y, player.Distace+1));
            }
            
            //filter Player
            var filteredPlayers = new List<Player>();
            //filteredPlayers = newPlayerList.FindAll(player => { (newPlayerList.Contains(player) || )})
            
            foreach (var player in newPlayerList)
            {
                int bestX = player.X;
                int bestY = player.Y;
                int shortestDist = Int32.MaxValue;
                
                foreach (var p in newPlayerList)
                {
                    if (p.X == player.X && p.Y == player.Y)
                    {
                        if (p.Distace < shortestDist)
                        {
                            shortestDist = p.Distace;
                            bestX = p.X;
                            bestY = p.Y;
                        }
                    }
                }
                filteredPlayers.Add(new Player(bestX, bestY, shortestDist));
            }
            
            // _players = filteredPlayers.GroupBy(x => x).Where(g => g.Count() == 1).Select(g => g.Key).ToList();
            _players = new List<Player>();

            var a = filteredPlayers.ToArray();

            for (int i = 0; i < a.Length; i++)
            {
                for (int k = i+1; k < a.Length; k++)
                {
                    if (a[i].Equals(a[k]))
                    {
                        a[i] = null;
                        break;
                    }
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                if(a[i] != null) _players.Add(a[i]);
            }
            
            //check if reached goal
            foreach (var player in _players)
            {
                if (player.X == _grid.GetLength(1) - 2 && player.Y == _grid.GetLength(0) - 1)
                {
                    //Console.ReadKey();
                    PrintGrid(player.X, player.Y, _players.ToArray());
                    return player.Distace;
                }
            }
            
            
            // foreach (var player in filteredPlayers)
            // {
            //     //_players.AddRange(filteredPlayers.FindAll(p => player.Equals(p)));
            //     _players.Add(filteredPlayers.Find(p => player.Equals(p)));
            // }
            //_players = filteredPlayers.Distinct().ToList();
            // Console.WriteLine(a);
            // _players = new List<Player>();
            //
            // foreach (var player in filteredPlayers)
            // {
            //     if(_players.Contains(p => p.Equals()))
            //         if (!player.Equals(p))
            //         {
            //             _players.Add(player);
            //         }
            //     
            // }
            // Console.ReadKey();
            // //Thread.Sleep(50);
            // PrintGrid(0, 0, _players.ToArray());
            Console.SetCursorPosition(_grid.GetLength(1) +2, 0);
            Console.WriteLine(minute);
        }
        foreach (var player in _players)
        {
            Console.WriteLine(player.X + " " + player.Y + " " + player.Distace);
        }

        return -1;
    }

    public void PrintGrid(int x, int y, Player [] players)
    {
        Console.ForegroundColor = ConsoleColor.Black;

        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < _grid.GetLength(0); i++)
        {
            for (int j = 0; j < _grid.GetLength(1); j++)
            {
                if (i == y && x == j)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('X');
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    Console.Write(_grid[i,j]);

                }
            }

            Console.WriteLine();
        }

        for (int i = 0; i < players.Length; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(players[i].X, players[i].Y);
            Console.Write('X');
        }
    }
}