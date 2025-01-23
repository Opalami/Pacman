namespace Pacman;

public class PacmanClass
{
    public int startX, startY;
    public PacmanClass(int startX, int startY)
    {
        this.startX = startX;
        this.startY = startY;
    }

    public void PlacePacman()
    {
        int x = Console.GetCursorPosition().Left;
        int y = Console.GetCursorPosition().Top;
        Console.SetCursorPosition(startX, startY);
        Console.Write('@');
        Console.SetCursorPosition(x, y);
    }

    public void MovePacman(ConsoleKey key, Map map)
    {
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (!map.CheckItem(startY, startX - 1, '#'))
                {
                    if (map.CheckItem(startY, startX - 1, 'O')) 
                    {
                        startX = map.map.GetLength(1) - 2;
                        if (map.CheckItem(startY, startX , '.')) 
                            map.SwitchItem(startY, startX, ' ');
                    }
                    else
                    {
                        if (map.CheckItem(startY, startX - 1, '.')) 
                            map.SwitchItem(startY, startX - 1, ' ');
                        startX--;
                    }
                    
                }

                break;

            case ConsoleKey.RightArrow:
                if (!map.CheckItem(startY, startX + 1, '#'))
                {
                    if (map.CheckItem(startY, startX + 1, 'O'))
                    {
                        if (map.CheckItem(startY, startX , '.')) 
                            map.SwitchItem(startY, startX, ' ');
                        startX = 1;
                    }
                    else
                    {
                        if (map.CheckItem(startY, startX + 1, '.')) 
                            map.SwitchItem(startY, startX + 1, ' ');
                        startX++;
                    }
                }

                break;

            case ConsoleKey.UpArrow:
                if (!map.CheckItem(startY - 1, startX, '#'))
                {
                    if (map.CheckItem(startY - 1, startX, '.')) 
                        map.SwitchItem(startY - 1, startX, ' ');
                    startY--;
                }
                break;
            
            case ConsoleKey.DownArrow:
                if (!map.CheckItem(startY + 1, startX, '#'))
                {
                    if (map.CheckItem(startY + 1, startX, '.')) 
                        map.SwitchItem(startY + 1, startX, ' ');
                    startY++;
                }
                break;
        }
    }
}