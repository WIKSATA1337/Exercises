public static class MazeSolver
{
    //Example
    //var maze = new string[,]
    //{
    //    { "x", "x", "x", "x", "x", "x", "x", "x", "x", "x", " ", "x" },
    //    { "x", " ", " ", " ", " ", " ", " ", " ", " ", "x", " ", "x" },
    //    { "x", " ", " ", " ", " ", " ", " ", " ", " ", "x", " ", "x" },
    //    { "x", " ", "x", "x", "x", "x", "x", "x", "x", "x", " ", "x" },
    //    { "x", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "x" },
    //    { "x", " ", "x", "x", "x", "x", "x", "x", "x", "x", "x", "x" },
    //};

    //Point start = new Point(10, 0);
    //Point end = new Point(1, 5);

    //var result = MazeSolver.Run(maze, "x", start, end);

    //foreach (var point in result)
    //{
    //  Console.WriteLine(point.x + " " + point.y);
    //}

    private static readonly int[,] dir = {
        {-1, 0},
        {1, 0},
        {0, -1},
        {0, 1},
    };

    public static Point[] Run(string[,] maze, string wall, Point start, Point end)
    {
        bool[,] seen = new bool[maze.Length, maze.Length];
        Stack<Point> path = new Stack<Point>();

        Walk(maze, wall, start, end, seen, path);

        return path.Reverse().ToArray();
    }

    private static bool Walk(string[,] maze, string wall, Point curr, Point end,
        bool[,] seen, Stack<Point> path)
    {
        if (curr.x < 0 || curr.x >= maze.GetLength(1) ||
            curr.y < 0 || curr.y > maze.GetLength(0))
        {
            return false;
        }

        if (maze[curr.y, curr.x].ToString() == wall)
        {
            return false;
        }

        if (curr.x == end.x && curr.y == end.y)
        {
            path.Push(end);
            return true;
        }

        if (seen[curr.y, curr.x])
        {
            return false;
        }

        seen[curr.y, curr.x] = true;
        path.Push(curr);

        for (int i = 0; i < dir.GetLength(0); ++i)
        {
            Point direction = new Point(dir[i, 0], dir[i, 1]);
            Point newCurr = new Point(curr.x + direction.x, curr.y + direction.y);
            if (Walk(maze, wall, newCurr, end, seen, path))
            {
                return true;
            }
        }

        path.Pop();

        return false;
    }
}

public class Point
{
    public int x { get; private set; }
    public int y { get; private set; }

    public Point(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
}