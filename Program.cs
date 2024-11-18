// David B. 11/15/24 Lab-9-Maze#2

using System.Diagnostics;
Stopwatch stopwatch = new Stopwatch();
Random rand = new Random();
string[] maze = File.ReadAllLines("maze.txt");
char[][] mazeChar = maze.Select(item => item.ToArray()).ToArray();
//List<string> listMaze = maze.ToList();
mainMenu();
showMaze();
int x = 0;
int y = 0;
int score = 0;
Console.WriteLine($"Your score is {score}");
Console.SetCursorPosition(x,y);


do
{
    if(Console.ReadKey(true).Key == ConsoleKey.W)
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
            x--;   
        }
        
    }else if (Console.ReadKey(true).Key == ConsoleKey.D)
    {
        
       if(tryMove(x, y, "w", mazeChar) == true)
        {
            x++;
        }
    }
    //int moveNumber = ;
    Console.SetCursorPosition(x,y);


    // if the cursor goes over a '^' then add to the score.
    if(mazeChar[y][x] == '^')
    {
        //listMaze[x][y].Replace("^", " ");
        mazeChar[y][x] = ' ';
        Console.Write(" ");
        score = score + 100;
        Console.SetCursorPosition(0,21);
        Console.WriteLine($"Your score is {score}");
        Console.SetCursorPosition(x,y);
    }

    if(mazeChar[y][x] == '$')
    {
        mazeChar[y][x] = ' ';
        Console.Write(" ");
        score = score + 200;
        Console.SetCursorPosition(0,21);
        Console.WriteLine($"Your score is {score}");
        Console.SetCursorPosition(x,y);
    }
    if(score >= 1000)
    {
        for(int i = 0; i<mazeChar.Count(); i++)
        {
            //Console.Write($"{mazeChar[i][0]}");
            for(int j = 0; j<mazeChar[i].Count(); j++)
            {
                if(mazeChar[i][j] == '|')
                {
                    mazeChar[i][j] = ' ';
                    Console.SetCursorPosition(j,i);
                    Console.Write(" ");
                }
            }
        }
        Console.SetCursorPosition(x,y);
    }
    
    for(int i = 0; i<mazeChar.Count(); i++)
{
    for(int j = 0; j<mazeChar[i].Count(); j++)
    {
        if(mazeChar[i][j] == '%')
        {
            mazeChar[i][j] = ' ';
            Console.SetCursorPosition(j,i);
            Console.Write(" ");
            if(rand.Next(0,4) == 0)
            {
                //move left
                if(canGuirdMove(i,j,"w", mazeChar) == true)
                {
                    mazeChar[i][j-1] = '%';
                    Console.SetCursorPosition(j-1,i);
                    Console.Write("%");
                }else
                {
                    mazeChar[i][j] = '%';
                    Console.SetCursorPosition(j,i);
                    Console.Write("%");
                }

            }else if(rand.Next(0,4) == 1)
            {
                //move up
                if(canGuirdMove(i,j,"n", mazeChar) == true)
                {
                    mazeChar[i-1][j] = '%';
                    Console.SetCursorPosition(j,i-1);
                    Console.Write("%");
                }else
                {
                    mazeChar[i][j] = '%';
                    Console.SetCursorPosition(j,i);
                    Console.Write("%");
                }

            }else if(rand.Next(0,4) == 2)
            {
                //move right
                if(canGuirdMove(i,j,"e", mazeChar) == true)
                {
                    mazeChar[i][j+1] = '%';
                    Console.SetCursorPosition(j+1,i);
                    Console.Write("%");
                }else
                {
                    mazeChar[i][j] = '%';
                    Console.SetCursorPosition(j,i);
                    Console.Write("%");
                }

            }else if(rand.Next(0,4) == 3)
            {
                //move down
                if(canGuirdMove(i,j,"s", mazeChar) == true)
                {
                    mazeChar[i+1][j] = '%';
                    Console.SetCursorPosition(j,i+1);
                    Console.Write("%");
                }else
                {
                    mazeChar[i][j] = '%';
                    Console.SetCursorPosition(j,i);
                    Console.Write("%");
                }
            }else
            {
                mazeChar[i][j] = '%';
                Console.SetCursorPosition(j,i);
                Console.Write("%");
            }
        }
    }
}
//Console.SetCursorPosition(0,0);
//showMaze();

Console.SetCursorPosition(x,y);

if(mazeChar[y][x] == '%')
{
    loseMenu();
    break;
}

if(mazeChar[y][x] == '#')
{
    winMenu();
    break;
}

}while(Console.CursorLeft != 33 || Console.CursorTop != 12);


void loseMenu()
{
    Console.Clear();
    Console.WriteLine("You died");
    Console.WriteLine($"Your score was {score}");
    Console.WriteLine($"Your time in the maze {stopwatch}");
}
void winMenu()
{
    Console.Clear();
    Console.WriteLine("You made it through the maze!");
    Console.WriteLine($"Your score was {score}");
    Console.WriteLine($"Your time in the maze {stopwatch}");
}

bool canGuirdMove(int i, int j, string direction, char[][] maze)
{
    //can it move left
    if(direction == "w")
    {
        if(j-1 < 0 || maze[i][j-1] == '*' || maze[i][j-1] == '^' || maze[i][j-1] == '|' || maze[i][j-1] == '%')
        {
            return false;
        }else
        {
            return true;
        }
    }else if(direction == "n")
    {// can it move up
        if(i-1 < 0 || maze[i-1][j] == '*' || maze[i-1][j] == '^' || maze[i-1][j] == '|' || maze[i-1][j] == '%')
        {
            return false;
        }else 
        {
            return true;
        }
    }else if(direction == "e")
    {// can it move right
        if(j+1 > maze.Length || maze[i][j+1] == '*' || maze[i][j+1] == '^' || maze[i][j+1] == '|' || maze[i][j+1] == '%')
        {
            return false;
        }else
        {
            return true;
        }
    }else if(direction == "s")
    {//can it move down
        if(i+1 > maze.Length || maze[i+1][j] == '*' || maze[i+1][j] == '^' || maze[i+1][j] == '|' || maze[i+1][j] == '%')
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


void showMaze()
{
    string[] maze = File.ReadAllLines("maze.txt");
    char[][] mazeChar = maze.Select(item => item.ToArray()).ToArray();
    for(int i = 0; i<mazeChar.Count(); i++)
    {
        //Console.Write($"{mazeChar[i][0]}");
        for(int j = 0; j<mazeChar[i].Count(); j++)
        {
            Console.Write($"{mazeChar[i][j]}");
        }
        Console.WriteLine();
    }
    // Console.Write($"{listMaze[0][0]}");
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
Console.Write("Press any key to start");
Console.ReadKey(true);
Console.Clear();
stopwatch.Start();
}

bool tryMove(int x, int y, string direction, char[][] maze)
{
//mazeChar[y][x+1] == '|'
    if(direction == "w")
    {
        if(x+1 > mazeChar[y].Length || mazeChar[y][x+1] == '*' || mazeChar[y][x+1] == '|')
        {
            return false;
        }else 
        {
            return true;
        }
    }else if(direction == "e")
    {
        if(x-1 < 0 || mazeChar[y][x-1] == '*' || mazeChar[y][x-1] == '|')
        {
            return false;
        }else
        {
            return true;
        }
    }else if(direction == "s")
    { 
        if(y+1 > mazeChar.Count() || mazeChar[y+1][x] == '*' || mazeChar[y+1][x] == '|')
        {
            return false;
        }else 
        {
            return true;
        }
    }else if (direction == "n")
    {
        if (y-1 < 0 || mazeChar[y-1][x] == '*' || mazeChar[y-1][x] == '|')
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