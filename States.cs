using System.Runtime.CompilerServices;

namespace Pacman;

public class States
{
    public static int score;
    private Map map;
    private int width;
    private PacmanClass pacman;

    public States(Map map, PacmanClass pacman)
    {
        this.map = map;
        this.pacman = pacman;
        width = this.map.map.GetLength(1);
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
        Console.ForegroundColor = color;
    }

    static void GetPoint()
    {
        score++;
    }
}