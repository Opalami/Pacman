using System.Data;

namespace Pacman;

public class PacmanClass
{
    public int startX, startY;
    public int TimeActive;
    private ConsoleColor PacmanColor;
    private ConsoleColor DefaultColor;
    public PacmanClass(int startX, int startY)
    {
        this.startX = startX;
        this.startY = startY;
        this.DefaultColor = Console.ForegroundColor;
        this.PacmanColor = this.DefaultColor;
        
    }

    public void PlacePacman()
    {
        int x = Console.GetCursorPosition().Left;
        int y = Console.GetCursorPosition().Top;
        Console.SetCursorPosition(startX, startY);
        Console.ForegroundColor = PacmanColor;
        Console.Write('@');
        Console.SetCursorPosition(x, y);
        TimeActive--;
    }

    public void MovePacman(ConsoleKey key, Map map, States state)
    {
        if (TimeActive-- <= 0) PacmanColor = this.DefaultColor;
        else TimeActive--;
        
        switch (key)
        {
            case ConsoleKey.LeftArrow:
                if (!map.CheckItem(startY, startX - 1, '#'))
                {
                    if (map.CheckItem(startY, startX - 1, 'O'))
                    {
                        startX = map.map.GetLength(1) - 2;
                        if (map.CheckItem(startY, startX, '.'))
                        {
                            States.GetPoint();
                            map.SwitchItem(startY, startX, ' ');
                        }
                    }

                    else
                    {
                        if (map.CheckItem(startY, startX - 1, '.'))
                        {
                            States.GetPoint();
                            map.SwitchItem(startY, startX - 1, ' ');
                        }
                        else if (map.CheckItem(startY, startX - 1, '*'))
                        {
                            state.ReloatTime();
                            map.SwitchItem(startY, startX - 1, ' ');
                            PacmanColor = ConsoleColor.Red;
                        }
                        startX--;
                    }
                }
                break;

            case ConsoleKey.RightArrow:
                if (!map.CheckItem(startY, startX + 1, '#'))
                {
                    if (map.CheckItem(startY, startX + 1, 'O'))
                    {
                        startX = 1;
                        if (map.CheckItem(startY, startX, '.'))
                        {
                            States.GetPoint();
                            map.SwitchItem(startY, startX, ' ');
                        }
                    }
                    else
                    {
                        if (map.CheckItem(startY, startX + 1, '.'))
                        {
                            States.GetPoint();
                            map.SwitchItem(startY, startX + 1, ' ');
                        }
                        else if (map.CheckItem(startY, startX + 1, '*'))
                        {
                            state.ReloatTime();
                            map.SwitchItem(startY, startX + 1, ' ');
                            PacmanColor = ConsoleColor.Red;

                        }
                        startX++;
                    }
                }

                break;

            case ConsoleKey.UpArrow:
                if (!map.CheckItem(startY - 1, startX, '#'))
                {
                    if (map.CheckItem(startY - 1, startX, '.'))
                    {
                        map.SwitchItem(startY - 1, startX, ' ');
                        States.GetPoint();
                    }
                    else if (map.CheckItem(startY - 1, startX, '*'))
                    {
                        state.ReloatTime();
                        map.SwitchItem(startY - 1, startX, ' ');
                        PacmanColor = ConsoleColor.Red;
                    }
                    startY--;
                }
                break;
            
            case ConsoleKey.DownArrow:
                if (!map.CheckItem(startY + 1, startX, '#'))
                {
                    if (map.CheckItem(startY + 1, startX, '.'))
                    {
                        map.SwitchItem(startY + 1, startX, ' ');
                        States.GetPoint();
                    }
                    else if (map.CheckItem(startY + 1, startX, '*'))
                    {
                        state.ReloatTime();
                        map.SwitchItem(startY + 1, startX, ' ');
                        PacmanColor = ConsoleColor.Red;

                    }

                    startY++;
                }
                break;
        }
        TimeActive--;
    }
}