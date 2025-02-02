using System.Runtime.CompilerServices;

namespace Pacman;

public class States
{
    public static int score;
    private Map map;
    private int width;
    private PacmanClass pacman;
    public static int TimeActive;

    public States(Map map, ref PacmanClass pacman)
    {
        this.map = map;
        this.pacman = pacman;
        width = this.map.map.GetLength(1);
        TimeActive = pacman.TimeActive;
    }
    
    public void PrintStates()
    {
        Console.SetCursorPosition(width+5, 3);
        ConsoleColor color = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Score: {score}");
        Console.SetCursorPosition(width+5, 4);
        Console.WriteLine($"X: {pacman.startX}");
        Console.SetCursorPosition(width+5, 5);
        Console.WriteLine($"Y: {pacman.startY}");
        Console.SetCursorPosition(width+5, 5);
        Console.WriteLine($"Time: {TimeActive}");
        Console.ForegroundColor = color;
    }

    static public void GetPoint()
    {
        score++;
    }

    public void ReloatTime()
    {
        TimeActive = 10;
    }
}