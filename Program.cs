// David B. 11/15/24 Lab-9-Maze#2

using System.Diagnostics;
Stopwatch stopwatch = new Stopwatch();
mainMenu();
showMaze();

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