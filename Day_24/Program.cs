using Day_24;

class Program
{
    public static void Main(String[] args)
    {
        Console.CursorVisible = false;
        Initializer initializer = new Initializer();
        Solution solution = new Solution(initializer.Player, initializer.Blizzards, initializer.Grid);
        Console.SetCursorPosition(0, 20);
        // Console.SetCursorPosition(0, initializer.Grid.GetLength(0)+1);
        Console.WriteLine(solution.Solve());
        ;
    }
}