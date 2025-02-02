namespace Pacman;

public class Map
{
    public char[,] map = new char[1,1];
    public char[,] GetMap(string path)
    {
        string file = File.ReadAllText(path);
        string[] lines = file.Split('\n');
        map = new char[lines.Length, lines[0].Length];
        for (int i = 0; i < lines.Length; i++)
        {
            for (int j = 0; j < lines[i].Length; j++)
            {
                if (lines[i][j] == '_')
                    map[i, j] = ' ';
                else if (lines[i][j] != ' ')
                    map[i, j] = lines[i][j];
                else map[i, j] = '.';
            }
        }
        return map;
    }

    public void PrintMap(ConsoleColor WallColor = ConsoleColor.White, ConsoleColor StartColor = ConsoleColor.White, ConsoleColor DotColor = ConsoleColor.White)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                switch (map[i, j])
                {
                    case '#':
                    {
                        Console.ForegroundColor = WallColor;
                        break;
                    }
                    case '.':
                    {
                        Console.ForegroundColor = DotColor;
                        break;
                    }

                    case '*':
                    {
                        Console.ForegroundColor = StartColor;
                        break;
                    }
                    
                }
                Console.Write(map[i, j]);
                Console.ForegroundColor = defaultColor;
            }
            Console.WriteLine();
        }
    }

    public bool CheckItem(int y, int x, char item) =>  map[y, x] == item;

    public void SwitchItem(int y, int x, char item) => map[y, x] = item;
    
}