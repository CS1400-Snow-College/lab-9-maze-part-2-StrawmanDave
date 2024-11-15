// David B. 11/15/24 Lab-9-Maze#2

using System.Diagnostics;
Stopwatch stopwatch = new Stopwatch();
string[] maze = File.ReadAllLines("maze.txt");
char[][] mazeChar = maze.Select(item => item.ToArray()).ToArray();
mainMenu();
showMaze();
int x = 0;
int y = 0;
Console.SetCursorPosition(x,y);

do
{
    if(Console.ReadKey(true).Key == ConsoleKey.Escape)
    {
        stopwatch.Stop();
        stopwatch.Reset();
        mainMenu();
        showMaze();
        x = 0;
        y = 0;
        Console.SetCursorPosition(x,y);
    }else if(Console.ReadKey(true).Key == ConsoleKey.W)
    {
         
        if(tryMove(x, y, "n", mazeChar) == true)
        {
            y --;
        }
        
    }else if(Console.ReadKey(true).Key == ConsoleKey.S)
    {
        
        if(tryMove(x, y, "s", mazeChar) == true)
        {
            y ++;
        }
        
    }else if(Console.ReadKey(true).Key == ConsoleKey.A)
    {
         
        if(tryMove(x, y, "e", mazeChar) == true)
        {
            if(x - 1 >= 0)
            {
                x--;
            }
            
        }
        
    }else if (Console.ReadKey(true).Key == ConsoleKey.D)
    {
        
       if(tryMove(x, y, "w", mazeChar) == true)
        {
            x++;
        }
    }
    Console.SetCursorPosition(x,y);

}while(Console.CursorLeft != 33 || Console.CursorTop != 12);



void showMaze()
{
    for(int i = 0; i<mazeChar.Count(); i++)
    {
        //Console.Write($"{mazeChar[i][0]}");
        for(int j = 0; j<mazeChar[i].Count(); j++)
        {
            Console.Write($"{mazeChar[i][j]}");
        }
        Console.WriteLine();
    }
    //Console.Write($"{mazeChar[0][0]}");
}

void mainMenu()
{
Console.Clear();
Console.Write("This is a maze that getting to the '#' will complete the maze");
Console.WriteLine();
Console.Write("Watch out for the guards they look like '%'");
Console.WriteLine();
Console.Write("You need to collect all the coins '^' to open the doors '|'.");
Console.WriteLine();
Console.Write("Each coin '^' raises your score.");
Console.WriteLine();
Console.Write("Use the w,a,s and d keys to move and you will see your time at the end");
Console.WriteLine();
Console.Write("You can press the escape key to startover");
Console.WriteLine();
Console.Write("Press any key to start");
Console.ReadKey(true);
Console.Clear();
stopwatch.Start();
}

bool tryMove(int x, int y, string direction, char[][] maze)
{

    if(direction == "w")
    {
        if(x > mazeChar[y].Length || mazeChar[y][x+1] == '*')
        {
            return false;
        }else 
        {
            return true;
        }
    }else if(direction == "e")
    {
        if(x-1 < 0 || mazeChar[y][x-1] == '*')
        {
            return false;
        }else
        {
            return true;
        }
    }else if(direction == "s")
    { 
        if(y > mazeChar.Count() || mazeChar[y+1][x] == '*')
        {
            return false;
        }else 
        {
            return true;
        }
    }else if (direction == "n")
    {
        if (y-1 < 0 || mazeChar[y-1][x] == '*')
        {
            return false;
        }else 
        {
            return true;
        }
    }else 
    {
        return false;
    }
}
