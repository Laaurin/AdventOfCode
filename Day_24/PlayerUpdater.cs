namespace Day_24;

public class PlayerUpdater
{
    public List<Player> update(Player player, char[,] map)
    {
        var players = new List<Player>();
        if(map[player.Y + 1, player.X] == '.') players.Add(new Player(player.X, player.Y + 1));
        if(map[player.Y - 1, player.X] == '.') players.Add(new Player(player.X, player.Y - 1));
        if(map[player.Y, player.X + 1] == '.') players.Add(new Player(player.X + 1, player.Y));
        if(map[player.Y, player.X - 1] == '.') players.Add(new Player(player.X - 1, player.Y));

        return players;
    }
}