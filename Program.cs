using System.Collections;

namespace Pacman;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        PacmanClass pacman = new PacmanClass(1, 1);
        Map map = new Map();
        map.GetMap("Map.txt");
        States states = new States(map, ref pacman);
        while (true)
        {
            Console.Clear();
            map.PrintMap(ConsoleColor.Blue, ConsoleColor.Red);
            states.PrintStates();
            pacman.PlacePacman();
            pacman.MovePacman(Console.ReadKey().Key, map, states);
        }    
    }
}           