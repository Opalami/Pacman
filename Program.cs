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
        States states = new States(map, pacman);
        while (true)
        {
            Console.Clear();
            map.PrintMap();
            states.PrintStates();
            pacman.PlacePacman();
            pacman.MovePacman(Console.ReadKey().Key, map);
        }    
    }
}           