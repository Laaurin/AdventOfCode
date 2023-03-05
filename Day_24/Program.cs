using Day_24;

class Program
{
    public static void Main(String[] args)
    {
        Initializer initializer = new Initializer();
        Solution solution = new Solution(initializer.Player, initializer.Blizzards, initializer.Grid);
        solution.Solve();
    }
}